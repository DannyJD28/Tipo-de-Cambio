using Application.Abstractions;
using Application.Products.Dtos;
using Mapster;
using MediatR;

namespace Application.Products.Queries;

public record GetProductsQuery() : IRequest<IReadOnlyList<ProductDto>>;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IReadOnlyList<ProductDto>>
{
    private readonly IProductRepository _repository;

    public GetProductsQueryHandler(IProductRepository repository) => _repository = repository;

    public async Task<IReadOnlyList<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync(cancellationToken);
        return products.Adapt<IReadOnlyList<ProductDto>>();
    }
}
