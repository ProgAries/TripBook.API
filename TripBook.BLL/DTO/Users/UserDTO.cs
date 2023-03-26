using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripBook.DAL.Entities;
using TripBook.DAL.Entities.Enums;

namespace TripBook.BLL.DTO.Users
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? NickName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhotoUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderType? Gender { get; set; }
        public string? HomeCountry { get; set; }
        public string? Biography { get; set; }
        public List<VisitedCities>? VisitedCities { get; set; }
        public List<CitiesToVisit>? CitiesToVisit { get; set; }


        public UserDTO(User u)
        {
            Id = u.Id;
            Name = u.Name;
            NickName = u.NickName;
            Email = u.Email;
            PhotoUrl = u.PhotoUrl;
            BirthDate = u.BirthDate;
            Gender = u.Gender;
            HomeCountry = u.HomeCountry;
            Biography = u.Biography;
            VisitedCities = u.VisitedCities;
            CitiesToVisit = u.CitiesToVisit;
        }
    }
}
