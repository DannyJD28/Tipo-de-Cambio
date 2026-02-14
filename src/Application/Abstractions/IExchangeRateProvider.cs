namespace Application.Abstractions;

public interface IExchangeRateProvider
{
    Task<(decimal Rate, string Provider, DateTime LastUpdated)> GetUsdToPenAsync(CancellationToken cancellationToken);
}
