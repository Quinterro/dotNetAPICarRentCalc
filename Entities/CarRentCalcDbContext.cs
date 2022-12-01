using Microsoft.EntityFrameworkCore;

namespace CarRentCalculator.Entities
{
    public class CarRentCalcDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     base.OnConfiguring(optionsBuilder);
        // }
    }
}
