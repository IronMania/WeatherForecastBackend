using MediatR;

namespace WebApi.Model.History
{
    public class HistoryRequest : IRequest<HistoryResponse>, INotification
    {
        public HistoryRequest(string city)
        {
            City = city;
        }
        public string City { get; private set; }
    }
}