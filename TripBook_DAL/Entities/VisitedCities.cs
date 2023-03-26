using System.ComponentModel.DataAnnotations;

namespace TripBook.DAL.Entities
{
    public class VisitedCities
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Experience { get; set; }
        public string? Recomandation { get; set; }
        public Gallery? gallery { get; set; }
        public Guid UserId { get; set; }
    }
}