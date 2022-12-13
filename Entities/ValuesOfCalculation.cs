using CarRentCalculator.Entities;
namespace CarRentCalculator.Entities;

public class ValuesOfCalculation
{
    public double OilPrice { get; set; }
    public double OnlyLoanPrice { get; set; }
    public double PriceNetto { get; set; }
    public double PriceBrutto { get; set; }

    public ValuesOfCalculation(double oilPrice, double onlyLoanPrice, double priceNetto, double priceBrutto)
    {
        OilPrice = oilPrice;
        OnlyLoanPrice = onlyLoanPrice;
        PriceNetto = priceNetto;
        PriceBrutto = priceBrutto;
    }
}