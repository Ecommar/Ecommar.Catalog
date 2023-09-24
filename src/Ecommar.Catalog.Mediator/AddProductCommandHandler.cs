using Ecommar.Catalog.Repositories.Interfaces;
using Ecommar.Catalog.Shared.Commands;
using MediatR;

namespace Ecommar.Catalog.Mediator;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, string?>
{
    private readonly ICatalogRepository _repository;
    public AddProductCommandHandler(ICatalogRepository repository)
    {
        _repository = repository;
    }

    public async Task<string?> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        return await _repository.AddProduct(request.Product);
    }
}
