using MediatR;

namespace Ecommar.Catalog.Shared.Commands;

public class DeleteProductCommand : IRequest<bool>
{
    public string ProductId { get; set; }

    public DeleteProductCommand(string productId)
    {
        ProductId = productId;
    }
}
