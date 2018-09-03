using System.Collections;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Model.Forecast;
using WebApi.Model.History;
using WebApi.Services.Forecast;

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
            var returnValue = await _mediator.Send(new ForeCastRequest
            {
                City = city
            });
            return returnValue;
        }

        [HttpGet("history")]
        public async Task<ActionResult<HistoryResponse>> History(string city)
        {
            var returnValue = await _mediator.Send(new HistoryRequest(city));
            return returnValue;
        }
    }
}