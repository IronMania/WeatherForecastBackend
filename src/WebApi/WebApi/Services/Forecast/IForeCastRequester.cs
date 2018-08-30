using System.Threading.Tasks;

namespace WebApi.Services.Forecast
{
    public interface IForeCastRequester
    {
        Task<OpenWeatherDto.Forecast> Get(string request);
    }
}