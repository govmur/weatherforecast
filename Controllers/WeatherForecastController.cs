﻿using Microsoft.AspNetCore.Mvc;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Cool", "Mild", "Warm" /*, "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"*/
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherModel> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}