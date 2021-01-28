using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapi01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast>Get()
        {
            return WeatherList(5,-20,55);
        }
        [HttpGet("{n}/{min}/{max}")]
        public IEnumerable<WeatherForecast>Get(int n, long min, long max)
        {
            return WeatherList(n,min,max);
        }
        [HttpGet("{n}")]
        public IEnumerable<WeatherForecast>Get(int n)
        {
            return WeatherList(-20,55,0);
        }
        public IEnumerable<WeatherForecast> WeatherList(int n, long min, long max)
        {
            var rng = new Random();
            return Enumerable.Range(1, n).Select(index => new WeatherForecast            
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
