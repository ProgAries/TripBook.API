using System.ComponentModel.DataAnnotations;

namespace TripBook.DAL.Entities
{
    public class CitiesToVisit
    {
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; } = string.Empty;
        public string? Comment { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}