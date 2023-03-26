using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripBook.DAL.Entities
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhotoUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderType Gender { get; set; }
        public string HomeCountry { get; set; }
        public string Biography { get; set; }
        public List<VisitedCities> visitedCities { get; set; }
        public List<CitiesToVisit> citiesToVisit { get; set; } 



    }
}
