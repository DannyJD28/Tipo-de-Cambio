using Application.Abstractions;
using Application.Products.Dtos;
using Mapster;
using MediatR;

namespace Application.Products.Commands;

public record UpdateProductCommand(Guid Id, string Name, decimal Price) : IRequest<ProductDto?>;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto?>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository) => _repository = repository;

    public async Task<ProductDto?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (product is null) return null;

        product.Name = request.Name;
        product.Price = request.Price;
        await _repository.UpdateAsync(product, cancellationToken);
        return product.Adapt<ProductDto>();
    }
}
