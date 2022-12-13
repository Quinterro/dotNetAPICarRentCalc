using CarRentCalculator.Entities;
using CarRentCalculator.Models;
using CarRentCalculator.Models.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CarRentCalculator.Models.CarRentCalc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentCalculator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarRentCalculatorController : ControllerBase
{
    private readonly ILogger<CarRentCalculatorController> _logger;

    public CarRentCalculatorController(ILogger<CarRentCalculatorController> logger)
    {
        _logger = logger;
    }
    
    private List<object> ClientInput;

    [HttpGet]
    public IActionResult GetValuesOfLoan([FromBody] ClientInput clientInput)
    {
        var validator = new InputValidation();
        var clientValues = new ClientInput(clientInput.ChosenCar, clientInput.DistanceDriven, clientInput.DriversLicenseObtainmentYear,
            clientInput.StartDate, clientInput.EndDate);
        var validationResult = validator.Validate(clientValues);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(x=>x.ErrorMessage);
            return BadRequest(errors);

        }

        var oilPrice = Calculation.OilPrice(clientValues);
        var onlyLoan = Calculation.OnlyLoan(clientValues);
        var priceNetto = Calculation.PriceNetto(clientValues);
        var priceBrutto = Calculation.PriceBrutto(clientValues);

        var result = new ValuesOfCalculation(oilPrice, onlyLoan, priceNetto, priceBrutto);
        
        return Ok(result);
    }
}