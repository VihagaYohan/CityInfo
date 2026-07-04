using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Context
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options)
            : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Name = "Colombo",
                    Description = "Commercial capital and larget city of Sri Lanka"
                },
                new City 
                {
                    Id = 2,
                    Name = "Kandy",
                    Description = "Cultrual capital set in the central hills"
                },
                new City 
                {
                    Id = 3, 
                    Name = "Galle",
                    Description = "Historic fort city on the southern coast"
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
