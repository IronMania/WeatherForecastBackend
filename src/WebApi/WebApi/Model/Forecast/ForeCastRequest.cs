using MediatR;

namespace WebApi.Model.Forecast
{
    public class ForeCastRequest :IRequest<ForecastResponse>
    {
        public string City { get; set; }
    }
}