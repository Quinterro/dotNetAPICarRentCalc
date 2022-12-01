using CarRentCalculator.Entities;

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
                new Car(1, "Premium", "Audi R8", 10, "Warszawa"),
                new Car(2, "Basic", "Opel Astra", 6, "Rzeszów"),
                new Car(3, "Medium", "Audi A6", 9, "Kraków"),
                new Car(4, "Standard", "Ford Focus", 6, "Lublin")
            };
            return cars;
        }
        
    }
}
