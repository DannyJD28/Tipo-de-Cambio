using System.Text.Json;
using Application.Abstractions;
using Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services;

public class ExchangeRateProvider : IExchangeRateProvider
{
    private readonly HttpClient _httpClient;
    private readonly ExchangeRateOptions _options;

    public ExchangeRateProvider(HttpClient httpClient, IOptions<ExchangeRateOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<(decimal Rate, string Provider, DateTime LastUpdated)> GetUsdToPenAsync(CancellationToken cancellationToken)
    {
        using var response = await _httpClient.GetAsync("USD", cancellationToken);
        response.EnsureSuccessStatusCode();

        using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync(cancellationToken));
        var rate = doc.RootElement.GetProperty("rates").GetProperty("PEN").GetDecimal();
        return (rate, _options.ProviderName, DateTime.UtcNow);
    }
}
