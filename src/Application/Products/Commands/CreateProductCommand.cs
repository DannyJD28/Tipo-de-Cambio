using Application.Abstractions;
using Application.Products.Dtos;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Products.Commands;

public record CreateProductCommand(string Name, decimal Price) : IRequest<ProductDto>;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository) => _repository = repository;

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product { Name = request.Name, Price = request.Price, CreatedAt = DateTime.UtcNow };
        await _repository.AddAsync(product, cancellationToken);
        return product.Adapt<ProductDto>();
    }
}
