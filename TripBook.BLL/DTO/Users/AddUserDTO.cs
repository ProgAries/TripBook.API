using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripBook.DAL.Entities.Enums;

namespace TripBook.BLL.DTO.Users
{
    public class AddUserDTO
    {

        [Required, MinLength(3), MaxLength(25)]
        public string Name { get; set; } = string.Empty;

        [MinLength(3), MaxLength(25)]
        public string? NickName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(8)]
        public string Password { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderType? Gender { get; set; }

        [MinLength(3), MaxLength(50)]
        public string? HomeCountry { get; set; }
        public string? Biography { get; set; }
    }
}
