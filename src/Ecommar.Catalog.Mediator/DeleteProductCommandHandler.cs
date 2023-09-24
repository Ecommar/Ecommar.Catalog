using Ecommar.Catalog.Repositories.Interfaces;
using Ecommar.Catalog.Shared.Commands;
using MediatR;

namespace Ecommar.Catalog.Mediator;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly ICatalogRepository _repository;
    public DeleteProductCommandHandler(ICatalogRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteProduct(request.ProductId);
    }
}
