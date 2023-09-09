using Ecommar.Catalog.Models.DTOs;
using MediatR;

namespace Ecommar.Catalog.Models.Commands;

public class AddProductCommand : IRequest<string>
{
    public ProductDto Product { get; set; }

    public AddProductCommand(ProductDto product)
    {
        Product = product;
    }
}
