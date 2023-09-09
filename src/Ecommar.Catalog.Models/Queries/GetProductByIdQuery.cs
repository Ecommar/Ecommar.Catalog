using Ecommar.Catalog.Models.DTOs;
using MediatR;

namespace Ecommar.Catalog.Models.Queries;

public class GetProductByIdQuery : IRequest<ProductDto?>
{
    public string ProductId { get; set; }

    public GetProductByIdQuery(string productId)
    {
        ProductId = productId;
    }
}
