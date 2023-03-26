using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripBook.DAL.Entities.Enums;

namespace TripBook.DAL.Entities
{
    public class User
    {

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? NickName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public byte[] EncodedPassword { get; set; } = Array.Empty<byte>();
        public Guid Salt { get; set; }
        public string? PhotoUrl { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public GenderType? Gender { get; set; }
        public string? HomeCountry { get; set; }
        public string? Biography { get; set; }
        public bool EmailConfirmed { get; set; } = false;
        public List<VisitedCities>? VisitedCities { get; set; }
        public List<CitiesToVisit>? CitiesToVisit { get; set; } 



    }
}
