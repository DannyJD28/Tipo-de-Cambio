namespace Infrastructure.Configuration;

public class ExchangeRateOptions
{
    public const string SectionName = "ExchangeRateProvider";
    public string BaseUrl { get; set; } = "https://open.er-api.com/v6/latest";
    public string ProviderName { get; set; } = "ER-API";
}
