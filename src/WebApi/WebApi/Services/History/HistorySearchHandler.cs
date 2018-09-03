using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.Model.History;

namespace WebApi.Services.History
{
    public class HistorySearchHandler : IRequestHandler<HistoryRequest, HistoryResponse>
    {
        private readonly HistoryContext _ctx;

        public HistorySearchHandler(HistoryContext ctx)
        {
            _ctx = ctx;
        }

        public Task<HistoryResponse> Handle(HistoryRequest notification, CancellationToken cancellationToken)
        {
            var search =
                _ctx.Searches.Where(search1 => search1.SearchName.Contains(notification.City.ToLower()))
                    .OrderByDescending(search1 => search1.SearchCount).Take(5).AsNoTracking()
                    .Select(search1 => search1.SearchName).ToList();
            return Task.FromResult(new HistoryResponse(search));
        }
    }
}