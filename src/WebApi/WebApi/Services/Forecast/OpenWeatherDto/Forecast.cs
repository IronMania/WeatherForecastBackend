using System.Collections.Generic;

namespace WebApi.Services.Forecast.OpenWeatherDto
{
    public class Forecast
    {
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public List<ForecastForATime> list { get; set; }
        public City city { get; set; }
    }
}