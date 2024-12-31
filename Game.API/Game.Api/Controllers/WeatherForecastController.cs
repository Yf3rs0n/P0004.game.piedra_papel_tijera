using Game.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Game.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var estudiantes = await _mediator.Send(new WeatherForecastQuery());
            return Ok(estudiantes);
        }
    }
}
