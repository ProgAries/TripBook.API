using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TripBook.BLL.DTO.List;
using TripBook.BLL.DTO.Users;
using TripBook.BLL.Interfaces;
using TripBook.DAL.Context;
using TripBook.DAL.Entities;

namespace TripBook.BLL.Services
{
    public class UserService
    {
        private readonly TripBookContext _context;
        private readonly IMailService _mailService;
        private readonly FileConfig _fileConfig;

        public UserService(TripBookContext context, IMailService mailService, FileConfig fileConfig)
        {
            _context = context;
            _mailService = mailService;
            _fileConfig = fileConfig;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _context.Users.Select(u => new UserDTO(u));
        }

        public bool AddUser(AddUserDTO add)
        {
            Guid  saltGuid = Guid.NewGuid();
            User u = new User
            {
                Name = add.Name,
                NickName = add.NickName,
                Email = add.Email,
                BirthDate = add.BirthDate,
                Gender = add.Gender,
                HomeCountry = add.HomeCountry,
                Biography = add.Biography,
                Salt = saltGuid,
                EncodedPassword = SHA512.HashData(Encoding.UTF8.GetBytes(add.Password + saltGuid.ToString()))
            };

            if (_context.Users.Any(me => me.Email == add.Email))
            {
                throw new ValidationException("email deja existant");
            }
            if (_context.Users.Any(me => me.NickName == add.NickName))
            {
                throw new ValidationException("nick-name deja existant");
            }
            if(add.Image != null)
            {
                string fileName = Guid.NewGuid().ToString() + ".jpg";
                File.WriteAllBytes(Path.Combine(_fileConfig.FilePath, "Images", fileName), add.Image);

                u.PhotoUrl = fileName;
            }

            u.EmailConfirmed = false;
            
            _mailService.SendConfirmationMail(u.Email);
            u.Id = Guid.NewGuid();
            _context.Add(u);
            _context.SaveChanges();
            return false;
        }

        public void delete(Guid id)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new KeyNotFoundException();
            }
            _context.Remove(user);
            _context.SaveChanges();
        }

        public void DeleteCity(string userid, int id)
        {
            
            CitiesToVisit? city = _context.CitiesToVisits.Where(u => u.UserId == new Guid(userid)).FirstOrDefault(u => u.Id == id);
            if (city == null)
            {
                throw new KeyNotFoundException();
            }
            _context.Remove(city);
            _context.SaveChanges();
        }

        public void DeleteVCity(string userid, int id)
        {

            VisitedCities? city = _context.Visiteds.Where(u => u.UserId == new Guid(userid)).FirstOrDefault(u => u.Id == id);
            if (city == null)
            {
                throw new KeyNotFoundException();
            }
            if(city.gallery != null)
            {
                _context.Remove(city.gallery);
            }
            _context.Remove(city);
            _context.SaveChanges();
        }



        public void EditUser(EditInfoUserDTO edit, string id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == new Guid(id));
            if (user == null)
            {
                throw new KeyNotFoundException();
            }
            user.BirthDate = edit.BirthDate;
            user.Biography = edit.Biography;
            user.Gender = edit.Gender;
            user.Name = edit.Name;
            user.NickName = edit.NickName;
            user.HomeCountry = edit.HomeCountry;
            if (edit.Image != null)
            {
                string fileName = Guid.NewGuid().ToString() + ".jpg";
                File.WriteAllBytes(Path.Combine(_fileConfig.FilePath, "Images", fileName), edit.Image);

                user.PhotoUrl = fileName;
            }
            _context.SaveChanges();
        }

        public void AddCityToVisit(string id, AddCityDTO add)
        {
            User user = _context.Users.Include(u => u.CitiesToVisit).FirstOrDefault(u => u.Id == new Guid(id));
            //CitiesToVisit city = _context.CitiesToVisits.FirstOrDefault(c => c.UserId == user.Id);
            if (user == null)
            {
                throw new KeyNotFoundException();
            }
            if(user.CitiesToVisit.Select(c => c.CityName).Contains(add.CityName))
            {
                throw new Exception("Cette ville a déjà été ajoutée");
            }
            user.CitiesToVisit.Add(new CitiesToVisit { CityName = add.CityName, Comment = add.Comment });
          //  city.CityName = add.CityName;
            //city.Comment = add.Comment;
            _context.SaveChanges();
        }

        public void AddVisitedCity(string id, AddVisitedCityDTO add)
        {
            User user = _context.Users.Include(u => u.VisitedCities).FirstOrDefault(u => u.Id == new Guid(id));
            if(user == null)
            {
                throw new KeyNotFoundException();
            }
            user.VisitedCities.Add(new VisitedCities { Name = add.Name, Experience = add.Experience, Recomandation = add.Recomandation });
            _context.SaveChanges();
        }

        public void AddGallery(int id,AddGalleryDTO add )
        {
            VisitedCities visited = _context.Visiteds.Include(v => v.gallery).FirstOrDefault(v => v.Id == id);
            if (visited == null)
            {
                throw new KeyNotFoundException();
            }
            visited.gallery = new Gallery { Title = add.Title };
            _context.SaveChanges();
        }

        //public void ConfirmEmail(string id)
        //{
        //    User user = _context.Users.FirstOrDefault(u => u.Id == new Guid(id));
        //    if (user == null)
        //    {
        //        throw new KeyNotFoundException();
        //    }
        //    user.EmailConfirmed = true;
        //    _context.SaveChanges();
        //}



        public UserDTO GetOne(string id)
        {
            return new UserDTO(_context.Users.Include(u => u.CitiesToVisit).Include(u => u.VisitedCities).ThenInclude(v => v.gallery ).FirstOrDefault(u => u.Id.ToString() == id));

        }

        public GetgalleryDTO Getgallery(int galleryId)
        {
            return new GetgalleryDTO(_context.Galleries.Include(i => i.GalleryImages).FirstOrDefault(g => g.GalleryId == galleryId));
        }

        public void AddImg(int id, byte[] img)
        {
            Gallery gallery = _context.Galleries.Include(g => g.GalleryImages).FirstOrDefault(g => g.GalleryId == id);
            if (img != null)
            {
                string fileName = Guid.NewGuid().ToString() + ".jpg";
                File.WriteAllBytes(Path.Combine(_fileConfig.FilePath, "GallerysImage", fileName), img);
                gallery.GalleryImages.Add(new GalleryImage { ImageUrl = fileName });
            }
            _context.SaveChanges();
        }

        public void DeleteImg(int id)
        {
            GalleryImage img = _context.GalleryImages.FirstOrDefault(i => i.ImageId == id);
            if(img == null)
            {
                throw new KeyNotFoundException();
            }

            File.Delete(Path.Combine(_fileConfig.FilePath, "GallerysImage", img.ImageUrl));
            _context.GalleryImages.Remove(img);
            _context.SaveChanges();
        }

    }

}