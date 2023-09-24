using Ecommar.Catalog.Shared.DTOs;
using MediatR;

namespace Ecommar.Catalog.Shared.Queries;

public class GetProductByIdQuery : IRequest<ProductDto?>
{
    public string ProductId { get; set; }

    public GetProductByIdQuery(string productId)
    {
        ProductId = productId;
    }
}
