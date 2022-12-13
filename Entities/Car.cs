using System.Collections.Specialized;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;

namespace CarRentCalculator.Entities
{
    
    public class Car
    {
        public int Id { get; set; }
        public enum PriceCategoryName
        {
            Basic,
            Standard,
            Medium,
            Premium
        }

        public PriceCategoryName PriceCategory { get; }
        public double Mileage { get; set; }
       
        public string CarModel { get; }
        public string Localization { get; set; }

        public Car(PriceCategoryName priceCategory, string carModel, double fuel, string localization)
        {
            PriceCategory = priceCategory;
             
            CarModel = carModel;
            
            Mileage = fuel;
            Localization = localization;
        }
    }
}
