using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripBook.DAL.Entities;

namespace TripBook.BLL.DTO.List
{
    public class AddVisitedCityDTO
    {
        [Required]
        public string Name { get; set; }
        public string? Experience { get; set; }
        public string? Recomandation { get; set; }
        public Gallery? gallery { get; set; }
        public Guid UserId { get; set; }
    }
}
