using congestion.calculator.Services.Interfaces;
using congestion_tax_calculator_net_core_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace congestion_tax_calculator_net_core_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxCalculatorController : ControllerBase
    {
        private ICongestionTaxCalculator _congestionTaxCalculator;
        public TaxCalculatorController(ICongestionTaxCalculator congestionTaxCalculator)
        {
            this._congestionTaxCalculator=congestionTaxCalculator;
        }

        [HttpPost("/get_tax")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll(GetTax dto)
        {
            return Ok(await _congestionTaxCalculator.GetTax(dto.vehicle,dto.dates,dto.city));
        }

        [HttpPost("/get_toll_fee")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll(GetTollFee dto)
        {
            return Ok(await _congestionTaxCalculator.GetTollFee(dto.date,dto.vehicle,dto.city));
        }
    }
}
