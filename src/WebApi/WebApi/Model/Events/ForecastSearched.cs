using MediatR;

namespace WebApi.Model.Events
{
    public class ForecastSearched : INotification
    {
        public ForecastSearched(string city)
        {
            City = city;
        }

        public string City { get; }
    }
}