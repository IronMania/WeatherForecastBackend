using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApi.Services.Forecast.OpenWeatherDto;

namespace WebApi.Services.Forecast
{
    public class ForeCastRequesterGeneral : IForeCastRequester
    {
        private readonly string _baseUrl;

        public ForeCastRequesterGeneral(IOptions<OpenWeatherSettings> settings)
        {
            _baseUrl = $"http://api.openweathermap.org/data/2.5/forecast?APPID={settings.Value.ApiKey}&units=metric";
        }

        public async Task<OpenWeatherDto.Forecast> Get(string request)
        {
            var client = new HttpClient();
            var result =
                await client.GetStringAsync(
                    $"{_baseUrl}&q={request},de");
            var tmp = JsonConvert.DeserializeObject<OpenWeatherDto.Forecast>(result);
            return tmp;
        }
    }
}