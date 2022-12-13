using CarRentCalculator.Entities;
using FluentValidation;
namespace CarRentCalculator.Models.Validators;

public class InputValidation: AbstractValidator<ClientInput>
{
    public InputValidation()
    {
        RuleFor(x => x.ChosenCar).LessThan(CarSeeder.GetCars().Count()).WithMessage("Wybierz samochód z listy");
        RuleFor(x => x.ChosenCar).GreaterThan(0).WithMessage("Podaj poprawny numer wybranego samochodu");
        RuleFor(x => x.DistanceDriven).GreaterThan(0).WithMessage("Podaj dodatnią wartość długości planowanej podróży");
        RuleFor(x => x.DistanceDriven).LessThan(1000000)
            .WithMessage("Podałeś zbyt wysoką wartość długości planowanej podróży");
        RuleFor(x => x.DriversLicenseObtainmentYear).LessThanOrEqualTo(DateTime.Now.Year)
            .WithMessage("Podaj poprawny rok otrzymania prawa jazdy");
        RuleFor(x => x.DriversLicenseObtainmentYear).GreaterThan(1918).WithMessage(
            "Podaj poprawny rok otrzymania prawa jazdy - Pierwsze prawo jazdy w Polsce zostało przyznane w 1918 roku, nie mogłeś zdobyć go wcześniej");
        RuleFor(x => x.StartDate).GreaterThanOrEqualTo(DateTime.Today).WithMessage("Podaj poprawną datę wypożyczenia - dzisiejszą będź późniejszą");
        RuleFor(x => x.StartDate).LessThan(x => x.EndDate).WithMessage("Podaj datę rozpoczęcia wypożycznia, która jest wcześniejsza niż data zakończenia wypożyczenia");
        RuleFor(x => x.EndDate).GreaterThan(x=>x.StartDate).WithMessage("Podaj datę zakończenia wypożycznia, która jest późniejsza niż data rozpoczęcia wypożyczenia");
        RuleFor(x => x.EndDate).LessThanOrEqualTo(DateTime.Today.AddYears(1)).WithMessage("Wypożyczenia samochodu można dokonać maksymalnie do daty za rok od daty dzisiejszej");
    }
}