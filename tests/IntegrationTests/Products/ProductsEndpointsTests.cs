using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests.Products;

public class ProductsEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ProductsEndpointsTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Get_Products_Should_Return_Ok()
    {
        var response = await _client.GetAsync("/api/v1/products");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Post_Product_Should_Return_Created()
    {
        var response = await _client.PostAsJsonAsync("/api/v1/products", new { name = "Keyboard", price = 80m });
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}
