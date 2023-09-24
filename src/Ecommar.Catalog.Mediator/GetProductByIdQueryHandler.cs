using Ecommar.Catalog.Repositories.Interfaces;
using Ecommar.Catalog.Shared.DTOs;
using Ecommar.Catalog.Shared.Queries;
using MediatR;

namespace Ecommar.Catalog.Mediator;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly ICatalogRepository _repository;
    public GetProductByIdQueryHandler(ICatalogRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetProductById(request.ProductId);
    }
}
