namespace Application.Products.Dtos;

public record ProductDto(Guid Id, string Name, decimal Price, DateTime CreatedAt);
