using CarRentCalculator.Entities;
using CarRentCalculator.DbContext;

namespace CarRentCalculator
{
    public class CarSeeder
    {
        private readonly CarRentCalcDbContext _dbContext;

        public CarSeeder(CarRentCalcDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Cars.Any())
                {
                    var cars = GetCars();
                    _dbContext.Cars.AddRange(cars);
                    _dbContext.SaveChanges();
                }
                
            }
        } 
        

        public static IEnumerable<Car> GetCars()
        {
            var cars = new List<Car>
            {
                new Car( Car.PriceCategoryName.Premium, "Audi R8", 10, "Warszawa"),
                new Car( Car.PriceCategoryName.Basic, "Opel Astra", 6, "Rzeszów"),
                new Car( Car.PriceCategoryName.Medium, "Audi A6", 9, "Kraków"),
                new Car( Car.PriceCategoryName.Standard, "Ford Focus", 6, "Lublin")
            };
            return cars;
        }
        
    }
}
