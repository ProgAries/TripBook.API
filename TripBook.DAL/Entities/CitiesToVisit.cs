namespace TripBook.DAL.Entities
{
    public class CitiesToVisit
    {
        public int Id { get; set; }
        public string CityName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
    }
}