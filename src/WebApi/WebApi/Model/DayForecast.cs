namespace WebApi.Model
{
    public class DayForecast
    {
        public DayForecast(decimal humidity, int temperature, decimal windSpeed)
        {
            Humidity = humidity;
            Temperature = temperature;
            WindSpeed = windSpeed;
        }
        public decimal Humidity { get; private set; }
        public int Temperature { get; private set; }
        public decimal WindSpeed { get; private set; }
    }
}