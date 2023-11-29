using congestion.calculator.Services.Interfaces;
using congestion_tax_calculator_net_core_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace congestion_tax_calculator_net_core_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CongestionTimeController : ControllerBase
    {
        ICongestionTimeService _congestionTimeService;
        public CongestionTimeController(ICongestionTimeService congestionTimeService)
        {
            this._congestionTimeService=congestionTimeService;
        }

        [HttpGet("/all")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _congestionTimeService.GetAll());
        }

        [HttpGet("/get")]
        [Produces("application/json")]
        public async Task<IActionResult> GetById(string city)
        {
            return Ok(await _congestionTimeService.GetAllByCity(city));
        }

        [HttpPost("post")]
        [Produces("application/json")]
        public async Task<IActionResult> Post(CreateCongestionTimeDto dto)
        {
            await _congestionTimeService.Create(dto.City, TimeSpan.Parse(dto.StartTime),TimeSpan.Parse(dto.EndTime), dto.Fee);
           return Ok(dto);
        }
    }
}