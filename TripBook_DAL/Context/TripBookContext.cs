using Microsoft.EntityFrameworkCore;
using TripBook.DAL.Configurations;
using TripBook.DAL.Entities;

namespace TripBook.DAL.Context
{
    public class TripBookContext : DbContext
    {

        public DbSet<User> Users { get{ return Set<User>(); }}
        public DbSet<CitiesToVisit> CitiesToVisits { get{ return Set<CitiesToVisit>(); }}
        public DbSet<VisitedCities> Visiteds { get{ return Set<VisitedCities>(); }}
        public DbSet<Gallery> Galleries { get{ return Set<Gallery>(); }}
        public DbSet<GalleryImage> GalleryImages { get{ return Set<GalleryImage>(); }}

        public TripBookContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfig());
        }

    }
}