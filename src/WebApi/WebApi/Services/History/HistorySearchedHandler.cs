using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApi.Model.Events;

namespace WebApi.Services.History
{
    public class HistorySearchedHandler : INotificationHandler<ForecastSearched>
    {
        private readonly HistoryContext _ctx;

        public HistorySearchedHandler(HistoryContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Handle(ForecastSearched notification, CancellationToken cancellationToken)
        {
            var search =
                _ctx.Searches.FirstOrDefault(search1 => search1.SearchName.Equals(notification.City.ToLower()));
            if (search == null)
            {
                search = new Search(notification.City.ToLower());
                _ctx.Searches.Add(search);
            }
            else
            {
                search.ItemSearched();
            }

            await _ctx.SaveChangesAsync(cancellationToken);
        }
    }
}