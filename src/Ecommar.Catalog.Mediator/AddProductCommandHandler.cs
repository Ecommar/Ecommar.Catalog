using Ecommar.Catalog.Models.Commands;
using Ecommar.Catalog.Models.DTOs;
using Ecommar.Catalog.Models.Queries;
using Ecommar.Catalog.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommar.Catalog.Mediator;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, string?>
{
    private readonly ICatalogRepository repository;
    public AddProductCommandHandler(ICatalogRepository repository)
    {
        this.repository = repository;
    }

    public async Task<string?> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        return await repository.AddProduct(request.Product);
    }
}
