using Application.Abstractions;
using Application.Products.Commands;
using Domain.Entities;
using FluentAssertions;
using Moq;

namespace UnitTests.Products;

public class CreateProductCommandHandlerTests
{
    [Fact]
    public async Task Handle_Should_Create_Product()
    {
        var repo = new Mock<IProductRepository>();
        Product? captured = null;
        repo.Setup(r => r.AddAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()))
            .Callback<Product, CancellationToken>((p, _) => captured = p)
            .Returns(Task.CompletedTask);

        var handler = new CreateProductCommandHandler(repo.Object);
        var result = await handler.Handle(new CreateProductCommand("Mouse", 120), CancellationToken.None);

        result.Name.Should().Be("Mouse");
        result.Price.Should().Be(120);
        captured.Should().NotBeNull();
    }
}
