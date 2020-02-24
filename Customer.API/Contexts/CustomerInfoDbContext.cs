using Customer.API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.Contexts
{
    public class CustomerInfoDbContext : DbContext
    {
        public DbSet<CustomerDto> Customers { get; set; }

        public DbSet<CountryDto> Countries { get; set; }

        public CustomerInfoDbContext(DbContextOptions<CustomerInfoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<CountryDto>().HasData(
                new CountryDto()
                {
                    CountryId = 1,
                    CountryName = "Sweden"
                },
                new CountryDto()
                {
                    CountryId = 2,
                    CountryName = "Belarus"
                },
                new CountryDto()
                {
                    CountryId = 3,
                    CountryName = "Germary"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
