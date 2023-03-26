namespace TripBook.DAL.Entities
{
    public class VisitedCities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Experience { get; set; }
        public string Recomandation { get; set; }
        public Gallery gallery { get; set; }
    }
}