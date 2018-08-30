using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Services.Forecast;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly ForecastSearchHandler _forecastSearchHandler;

        public WeatherController(ForecastSearchHandler forecastSearchHandler)
        {
            _forecastSearchHandler = forecastSearchHandler;
        }

        [HttpGet("forecast")]
        public async Task<ActionResult<ForecastResponse>> Forecast(string city)
        {
            var returnValue = await _forecastSearchHandler.ForecastResponse(new ForeCastRequest
            {
                City = city
            });
            return returnValue;
        }
    }
}