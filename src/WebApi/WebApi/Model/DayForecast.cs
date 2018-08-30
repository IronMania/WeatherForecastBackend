using System;
using System.Collections.Generic;

namespace WebApi.Model
{
    public class DayForecast
    {
        public DayForecast(DateTime day, IEnumerable<TimeForecast> times)
        {
            Day = day;
            Times = times;
        }

        public DateTime Day { get; }
        public IEnumerable<TimeForecast> Times { get; }
    }
}