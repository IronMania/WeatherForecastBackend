using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApi.Model.Events;
using WebApi.Model.Forecast;

namespace WebApi.Services.Forecast
{
    public class ForecastSearchHandler : IRequestHandler<ForeCastRequest, ForecastResponse>
    {
        private readonly IMediator _mediator;
        private readonly IForeCastRequester _requester;

        public ForecastSearchHandler(IForeCastRequester requester, IMediator mediator)
        {
            _requester = requester;
            _mediator = mediator;
        }

        public async Task<ForecastResponse> Handle(ForeCastRequest request, CancellationToken cancellationToken)
        {
            var forecast = await _requester.Get(request.City);
            await _mediator.Publish(new ForecastSearched(request.City), cancellationToken);
            return ForecastMapper.MapToDomain(forecast);
        }
    }
}