using Ecommar.Catalog.Models.DTOs;
using Ecommar.Catalog.Models.Queries;
using Ecommar.Catalog.Repositories.Interfaces;
using MediatR;

namespace Ecommar.Catalog.Mediator;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>?>
{
    private readonly ICatalogRepository repository;
    public GetAllProductsQueryHandler(ICatalogRepository repository)
    {
        this.repository = repository;
    }

    public async Task<List<ProductDto>?> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllProducts();
    }
}
