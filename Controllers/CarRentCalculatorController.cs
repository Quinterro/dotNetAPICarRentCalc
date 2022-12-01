using CarRentCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    // GET: api/CarRentCalculator
    [HttpPost]
    public OkObjectResult POST()
    {
        double[] values =
        {
            CarRentCalc.Calculation.OilPrice(),
            CarRentCalc.Calculation.OnlyLoan(),
            CarRentCalc.Calculation.PriceNetto(),
            CarRentCalc.Calculation.PriceBrutto()
        };
        var carLoanValues = new List<double>(values);

        return Ok(new { CarLoanValues = carLoanValues});
    }
    //
    // // GET apiCarRentCalculator/5
    // [HttpGet("{id}")]
    // public string Get(int id)
    // {
    //     return "value";
    // }
    //
    // // POST api/CarRentCalculator
    // [HttpPost]
    // public void Post([FromBody] string value)
    // {
    // }
    //
    // // PUT api/CarRentCalculator/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }
    //
    // // DELETE api/CarRentCalculator/5
    // [HttpDelete("{id}")]
    // public void Delete(int id)
    // {
    // }
}