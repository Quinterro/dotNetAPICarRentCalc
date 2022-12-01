using System.Collections.Specialized;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;

namespace CarRentCalculator.Entities
{
    public class Car
    {
        static int counter = 0;
        public int Id { get; set; }
        public double Factor { get; }
        public double Mileage { get; set; }
       
        public string CarModelName { get; }
        private int NumberOfCars { get; }
        public string Localization { get; set; }

        public Car(int id, string priceCatName, string carModelName, double fuel, string localization)
        {
            Interlocked.Increment(ref counter);
            Id = id;
            Factor = priceCatName switch
            {
                "Basic" => 1,
                "Standard" => 1.3,
                "Medium" => 1.6,
                "Premium" => 2.0,
                _ => Factor
            };

            if (carModelName == CarModel.Name)
            {
                CarModelName = carModelName;
                NumberOfCars = CarModel.NumberOfAvailableCars;
            }
            
            Mileage = fuel;
            Localization = localization;
        }
        
        ~Car()
        {
            Interlocked.Decrement(ref counter);
        }
        
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }
        
        public static int TotalCount() 
        {  
            return counter; 
        }
        
    }
}
