using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultipleImplementation.Repositories;

namespace MultipleImplementation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        private readonly IShoppingCartRepository _shoppingCart;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IShoppingCartRepository shoppingCart)
        {
            _logger = logger;
            _shoppingCart = shoppingCart;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogCritical((string?)_shoppingCart.GetCart());
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}