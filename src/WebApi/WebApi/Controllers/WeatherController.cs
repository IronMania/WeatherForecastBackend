using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpGet("forecast")]
        public ActionResult<IEnumerable<DayForecast>> Forecast(string city)
        {
            return new[] {new DayForecast(5, 5, 5), new DayForecast(1, 2, 4)};
        }
    }
}