namespace WebApi.Services.Forecast.OpenWeatherDto
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coordinate coord { get; set; }
        public string country { get; set; }
    }
}