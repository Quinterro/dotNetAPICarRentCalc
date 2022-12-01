using CarRentCalculator.Attributes;
using System.ComponentModel.DataAnnotations;
using CarRentCalculator.Entities;


namespace CarRentCalculator.Models;

public class CarRentCalc
{
         

    [Required(ErrorMessage = "Wprowadź nr modelu samochodu który chcesz wypożyczyć")]
    //[Range(1,Car.count)]
    private static int ChosenCar { get; set; }

    [Required(ErrorMessage = "Wprowadź datę rozpoczęcia wypożyczenia")]
    [DateRange(ErrorMessage = "Wprowadź datę od dziś do daty za rok")]
    public static DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Wprowadź datę zakończenia wypożczenia")]
    [DateRange(ErrorMessage = "Wprowadź datę od dziś do daty za rok")]
    public static DateTime EndDate { get; set; }

    [Required(ErrorMessage = "Wprowadź rok otrzymania prawa jazdy")]
    [YearRange(Config.minYear, ErrorMessage = "Podaj poprawny rok")]
    public static int DriversLicenseObtainmentYear { get; set; }

    [Required(ErrorMessage = "Wprowadź ilość kilomentrów do przejechania")]
    [Range(Config.distanceMin, Config.distanceMax, ErrorMessage = "Podałeś niewłaściwą liczbę kilometrów (podaj liczbę z przedziału 0 - 1 000 000")]
    private static double DistanceDriven { get; set; }

    private static List<Car> listOfCars = CarSeeder.GetCars().ToList();
    //public Cars Car { get; set; }
        
    public class Calculation
    {
        public static double OilPrice()
        { 
                
            var oilPrice = DistanceDriven / 100 * listOfCars[ChosenCar-1].Mileage*Config.fuelPrice;
            return oilPrice;
        }
        
        public static double OnlyLoan()
        {
            var baseLoan = Config.baseLoanValue * (EndDate - StartDate).TotalDays;
            return baseLoan;
        }
        
        public static double PriceNetto()
        {
            var wholeLoanPrice = 0.0;
            wholeLoanPrice += OnlyLoan();
            wholeLoanPrice*=listOfCars[ChosenCar-1].Factor;
                
            if (Config.thisYear - DriversLicenseObtainmentYear < 5)
            {
                wholeLoanPrice *= Config.driversLongevityRate;
            }
                
            if (listOfCars[ChosenCar].CarModel.NumberOfAvailableCars < 3)
            {
                wholeLoanPrice *= Config.amountOfCarsRate;
            }

            wholeLoanPrice += OilPrice();
            return wholeLoanPrice;
        }
        
        public static double PriceBrutto()
        {
            var priceBrutto = PriceNetto() * Config.vatRate;
            return priceBrutto;
        }
        
    }

}