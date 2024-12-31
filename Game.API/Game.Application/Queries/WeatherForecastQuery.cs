using MediatR;
using Game.Domain.Entities;

namespace Game.Application.Queries
{
    // Query que representa la solicitud
    public class WeatherForecastQuery : IRequest<List<WeatherForecast>>
    { }
    public class ConsultarWeatherForecastQueryHandler : IRequestHandler<WeatherForecastQuery, List<WeatherForecast>>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<List<WeatherForecast>> Handle(WeatherForecastQuery request, CancellationToken cancellationToken)
        {
            // Simula la generación de datos (puedes moverlo a un servicio si es necesario)
            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();

            return await Task.FromResult(forecasts); // Retorna una Task simulada
        }
    }
}