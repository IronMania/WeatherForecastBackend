using System;
using System.Collections.Generic;

namespace WebApi.Services.Forecast.OpenWeatherDto
{
    public class ForecastForATime
    {
        public int dt { get; set; }
        public MainData main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Rain rain { get; set; }
        public DateTime dt_txt { get; set; }
    }
}