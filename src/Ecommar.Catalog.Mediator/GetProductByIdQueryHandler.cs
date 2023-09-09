using Ecommar.Catalog.Models.DTOs;
using Ecommar.Catalog.Models.Queries;
using Ecommar.Catalog.Repositories.Interfaces;
using MediatR;

namespace Ecommar.Catalog.Mediator;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly ICatalogRepository repository;
    public GetProductByIdQueryHandler(ICatalogRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetProductById(request.ProductId);
    }
}
