using CarRentCalculator.Entities;
using static CarRentCalculator.Entities.Car;


namespace CarRentCalculator.Models;

public class CarRentCalc
{
    

    // [Required(ErrorMessage = "Wprowadź nr modelu samochodu który chcesz wypożyczyć")]
    //[Range(1,Car.count)]
    private static int ChosenCar { get; set; }

   // [Required(ErrorMessage = "Wprowadź datę rozpoczęcia wypożyczenia")]
   // [DateRange(ErrorMessage = "Wprowadź datę od dziś do daty za rok")]
    public static DateTime StartDate { get; set; }

  //  [Required(ErrorMessage = "Wprowadź datę zakończenia wypożczenia")]
   // [DateRange(ErrorMessage = "Wprowadź datę od dziś do daty za rok")]
    public static DateTime EndDate { get; set; }

   // [Required(ErrorMessage = "Wprowadź rok otrzymania prawa jazdy")]
    //[YearRange(minYear, ErrorMessage = "Podaj poprawny rok")]
    public static int DriversLicenseObtainmentYear { get; set; }

   // [Required(ErrorMessage = "Wprowadź ilość kilomentrów do przejechania")]
    //[Range(distanceMin, distanceMax, ErrorMessage = "Podałeś niewłaściwą liczbę kilometrów (podaj liczbę z przedziału 0 - 1 000 000")]
    private static double DistanceDriven { get; set; }

    private static readonly List<Car> ListOfCars = CarSeeder.GetCars().ToList();
    //public Cars Car { get; set; }

    
        
    
        
    public class Calculation
    {
        
        private static int thisYear = DateTime.Now.Year;
        private const double fuelPrice = 7.3;
        private const double vatRate = 1.23;
        private const double driversLongevityRate = 1.2;
        private const double amountOfCarsRate = 1.15;
        private const double baseLoanValue = 100.0;
        private static PriceCategoryName Factor = ListOfCars.FirstOrDefault(x => x.Id == ChosenCar - 1).PriceCategory;
        
            
        
        
        public static double OilPrice(ClientInput clientInput)
        {
            
            var oilPrice = clientInput.DistanceDriven / 100 * ListOfCars.FirstOrDefault(x=>x.Id == clientInput.ChosenCar-1).Mileage*fuelPrice;
            return oilPrice;
        }
        
        public static double OnlyLoan(ClientInput clientInput)
        {
            var baseLoan = baseLoanValue * (clientInput.EndDate - clientInput.StartDate).TotalDays;
            return baseLoan;
        }

        public static double PriceNetto(ClientInput clientInput)
        {
            
            var wholeLoanPrice = 0.0;
            wholeLoanPrice += OnlyLoan(clientInput);

            double factor = 0;
            factor = Factor switch
            {
                PriceCategoryName.Basic => 1,
                PriceCategoryName.Standard => 1.3,
                PriceCategoryName.Medium => 1.6,
                PriceCategoryName.Premium => 2.0,
                _ => factor
            };

            wholeLoanPrice*=factor;
                
            if (thisYear - clientInput.DriversLicenseObtainmentYear < 5)
            {
                wholeLoanPrice *= driversLongevityRate;
            }
                
            if (ListOfCars.FirstOrDefault(x=>x.Id == clientInput.ChosenCar-1).CarModel.Length < 3)
            {
                wholeLoanPrice *= amountOfCarsRate;
            }

            wholeLoanPrice += OilPrice(clientInput);
            return wholeLoanPrice;
        }
        
        public static double PriceBrutto(ClientInput clientInput)
        {
            var priceBrutto = PriceNetto(clientInput) * vatRate;
            return priceBrutto;
        }
        
    }

}