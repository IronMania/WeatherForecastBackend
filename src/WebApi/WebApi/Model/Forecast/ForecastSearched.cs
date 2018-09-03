using MediatR;

namespace WebApi.Model.Forecast
{
    public class ForecastSearched : INotification
    {
        public ForecastSearched(string city)
        {
            City = city;
        }
        public string City { get; private set; }
    }
}