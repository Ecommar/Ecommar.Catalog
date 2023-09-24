using Ecommar.Catalog.Repositories.Interfaces;
using Ecommar.Catalog.Shared.DTOs;
using Ecommar.Catalog.Shared.Queries;
using MediatR;

namespace Ecommar.Catalog.Mediator;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>?>
{
    private readonly ICatalogRepository _repository;
    public GetAllProductsQueryHandler(ICatalogRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductDto>?> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllProducts();
    }
}
