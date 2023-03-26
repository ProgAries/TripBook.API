using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TripBook.BLL.DTO.Users;
using TripBook.DAL.Context;
using TripBook.DAL.Entities;

namespace TripBook.BLL.Services
{
    public class LoginService
    {
        private readonly TripBookContext _context;

        public LoginService(TripBookContext context)
        {
            _context = context;
        }


        public UserDTO Login(UserLoginDTO userLogin)
        {
            User? user = _context.Users.FirstOrDefault( u => u.Email == userLogin.Email);
            if (user is null)
            {
                throw new Exception("E-Mail or Password are incorrect");
            }
            if (!user.EncodedPassword.SequenceEqual(SHA512.HashData(Encoding.UTF8.GetBytes(userLogin.Password + user.Salt))))
            {
                throw new Exception("E-Mail or Password are incorrect");
            }
            return new UserDTO(user);
        }
    }
}
