using Ecommar.Catalog.Shared.DTOs;
using MediatR;

namespace Ecommar.Catalog.Shared.Commands;

public class UpdateProductCommand : IRequest<bool>
{
    public ProductDto Product { get; set; }

    public UpdateProductCommand(ProductDto product)
    {
        Product = product;
    }
}
