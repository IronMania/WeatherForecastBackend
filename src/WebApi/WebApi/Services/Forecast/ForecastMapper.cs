using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Model;
using WebApi.Model.Forecast;
using WebApi.Services.Forecast.OpenWeatherDto;

namespace WebApi.Services.Forecast
{
    public class ForecastMapper
    {
        public static ForecastResponse MapToDomain(OpenWeatherDto.Forecast forecast)
        {
            var forecastByDate = forecast.list.GroupBy(list => list.dt_txt.Date);

            var forecastsDays = MapDayForeCasts(forecastByDate);

            return new ForecastResponse(forecastsDays);
        }

        private static IEnumerable<DayForecast> MapDayForeCasts(
            IEnumerable<IGrouping<DateTime, ForecastForATime>> forecastsForMultipleDays)
        {
            return forecastsForMultipleDays.Select(forecastsForADay =>
                new DayForecast(forecastsForADay.Key.Date, MapTimeForecasts(forecastsForADay)));
        }

        private static IEnumerable<TimeForecast> MapTimeForecasts(IEnumerable<ForecastForATime> forecastsForADay)
        {
            return forecastsForADay.Select(list =>
                new TimeForecast(list.dt_txt, list.main.humidity, list.main.temp, list.wind.speed));
        }
    }
}