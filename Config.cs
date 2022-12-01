using CarRentCalculator.Entities;

namespace CarRentCalculator
{
    public static class Config
    {
        private static CarModel AudiR8 = new(1,"Audi R8", 1);
        private static CarModel OpelAstra = new(2,"Opel Astra", 7);
        private static CarModel FordFocus = new(3,"Ford Focus", 5);
        private static CarModel AudiA6 = new(4, "Audi A6", 3);
        
        public const double distanceMin = 0.0;
        public const double distanceMax = 1000000.0;
        public const int minYear = 1918;
        
        public static int thisYear = DateTime.Now.Year;
        public const double fuelPrice = 7.3;
        public const double vatRate = 1.23;
        public const double driversLongevityRate = 1.2;
        public const double amountOfCarsRate = 1.15;
        public const double baseLoanValue = 100.0;

    }
}
