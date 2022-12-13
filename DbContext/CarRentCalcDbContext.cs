using CarRentCalculator.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentCalculator.DbContext;

public class CarRentCalcDbContext: Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Car> Cars { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     base.OnConfiguring(optionsBuilder);
    // }
}