using CarCredit.API.Models.Borrower.Entity;
using CarCredit.API.Models.Car.Entity;
using CarCredit.API.Models.CarType.Entity;
using CarCredit.API.Models.Credit.Entity;
using Microsoft.EntityFrameworkCore;

namespace CarCredit.API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Credit> Credits { get; set; } = null!;
        public DbSet<Borrower> Borrowers { get; set; } = null!;
        public DbSet<CarType> CarTypes { get; set; } = null!;

    }
}
