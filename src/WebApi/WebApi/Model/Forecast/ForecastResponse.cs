using System.Collections.Generic;

namespace WebApi.Model.Forecast
{
    public class ForecastResponse
    {
        public ForecastResponse(IEnumerable<DayForecast> forecastsPerDay)
        {
            ForecastsPerDay = forecastsPerDay;
        }

        public IEnumerable<DayForecast> ForecastsPerDay { get; }
    }
}