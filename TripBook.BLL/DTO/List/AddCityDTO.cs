using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripBook.BLL.DTO.List
{
    public class AddCityDTO
    {
        [Required]
        public string CityName { get; set; } = string.Empty;
        public string? Comment { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}
