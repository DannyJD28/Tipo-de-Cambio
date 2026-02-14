using Application.Abstractions;
using Application.ExchangeRate.Queries;
using FluentAssertions;
using Moq;

namespace UnitTests.ExchangeRate;

public class GetUsdPenExchangeRateQueryHandlerTests
{
    [Fact]
    public async Task Handle_Should_Return_Exchange_Rate()
    {
        var provider = new Mock<IExchangeRateProvider>();
        provider.Setup(x => x.GetUsdToPenAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync((3.79m, "MockProvider", DateTime.UtcNow));

        var handler = new GetUsdPenExchangeRateQueryHandler(provider.Object);
        var result = await handler.Handle(new GetUsdPenExchangeRateQuery(), CancellationToken.None);

        result.BaseCurrency.Should().Be("USD");
        result.TargetCurrency.Should().Be("PEN");
        result.Rate.Should().Be(3.79m);
        result.Provider.Should().Be("MockProvider");
    }
}
