using System.Net.Http;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model.Forecast;
using WebApi.Model.History;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("forecast")]
        public async Task<ActionResult<ForecastResponse>> Forecast(string city)
        {
            try
            {
                var returnValue = await _mediator.Send(new ForeCastRequest
                {
                    City = city
                });
                return returnValue;
            }
            catch (HttpRequestException exception)
            {
                if (exception.Message.Contains("401"))
                    return NotFound($"Specify a valid city or postal code in Germany. '{city}' is not valid!");
                throw;
            }
        }

        [HttpGet("history")]
        public async Task<ActionResult<HistoryResponse>> History(string city)
        {
            var returnValue = await _mediator.Send(new HistoryRequest(city));
            return returnValue;
        }
    }
}