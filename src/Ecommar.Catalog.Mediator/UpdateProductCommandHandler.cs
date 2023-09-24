using Ecommar.Catalog.Repositories.Interfaces;
using Ecommar.Catalog.Shared.Commands;
using MediatR;

namespace Ecommar.Catalog.Mediator;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly ICatalogRepository _repository;
    public UpdateProductCommandHandler(ICatalogRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        return await _repository.UpdateProduct(request.Product);
    }
}
