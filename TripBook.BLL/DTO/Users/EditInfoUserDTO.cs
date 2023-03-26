using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripBook.DAL.Entities.Enums;

namespace TripBook.BLL.DTO.Users
{
    public class EditInfoUserDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? NickName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderType? Gender { get; set; }
        public string? HomeCountry { get; set; }
        public string? Biography { get; set; }
    }
}
