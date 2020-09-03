using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

using HelloBlazor.Common.Model;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloBlazor.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        Random RandomGenerator { get; set; } = default!;

        public WeatherForecastController() =>
            RandomGenerator = new Random();

        [HttpGet]
        public IEnumerable<WeatherForecast> Get() => 
            Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = RandomGenerator.Next(-20, 55),
                Summary = WeatherForecast.Summaries[RandomGenerator.Next(WeatherForecast.Summaries.Length)]
            })
            .ToArray();

        [HttpPost]
        public void Post(WeatherForecast forecast) =>
            Console.WriteLine(JsonSerializer.Serialize(forecast));
    }
}
