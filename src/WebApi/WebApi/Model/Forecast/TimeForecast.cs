using System;

namespace WebApi.Model.Forecast
{
    public class TimeForecast
    {
        public TimeForecast(DateTime time, decimal humidity, double temperature, double windSpeed)
        {
            Time = time;
            Humidity = humidity;
            Temperature = temperature;
            WindSpeed = windSpeed;
        }

        public DateTime Time { get; }
        public decimal Humidity { get; }
        public double Temperature { get; }
        public double WindSpeed { get; }
    }
}