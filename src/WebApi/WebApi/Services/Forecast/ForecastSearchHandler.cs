using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Services.Forecast
{
    public class ForecastSearchHandler
    {
        private readonly IForeCastRequester _requester;

        public ForecastSearchHandler(IForeCastRequester requester)
        {
            _requester = requester;
        }

        public async Task<ForecastResponse> ForecastResponse(ForeCastRequest request)
        {
            var forecast = await _requester.Get(request.City);

            return ForecastMapper.MapToDomain(forecast);
        }
    }
}