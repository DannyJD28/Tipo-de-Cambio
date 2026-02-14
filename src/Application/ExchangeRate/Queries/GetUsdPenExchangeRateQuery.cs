using Application.Abstractions;
using Application.ExchangeRate.Dtos;
using MediatR;

namespace Application.ExchangeRate.Queries;

public record GetUsdPenExchangeRateQuery() : IRequest<ExchangeRateDto>;

public class GetUsdPenExchangeRateQueryHandler : IRequestHandler<GetUsdPenExchangeRateQuery, ExchangeRateDto>
{
    private readonly IExchangeRateProvider _provider;

    public GetUsdPenExchangeRateQueryHandler(IExchangeRateProvider provider) => _provider = provider;

    public async Task<ExchangeRateDto> Handle(GetUsdPenExchangeRateQuery request, CancellationToken cancellationToken)
    {
        var (rate, provider, updated) = await _provider.GetUsdToPenAsync(cancellationToken);
        return new ExchangeRateDto("USD", "PEN", rate, provider, updated);
    }
}
