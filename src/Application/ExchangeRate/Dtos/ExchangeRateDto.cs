namespace Application.ExchangeRate.Dtos;

public record ExchangeRateDto(string BaseCurrency, string TargetCurrency, decimal Rate, string Provider, DateTime LastUpdated);
