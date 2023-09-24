using Ecommar.Catalog.Shared.DTOs;
using MediatR;

namespace Ecommar.Catalog.Shared.Commands;

public class AddProductCommand : IRequest<string?>
{
    public ProductDto Product { get; set; }

    public AddProductCommand(ProductDto product)
    {
        Product = product;
    }
}
