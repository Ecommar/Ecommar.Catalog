using MediatR;
using Microsoft.AspNetCore.Http;

namespace Ecommar.Catalog.Services.Interfaces;

public interface ICatalogService
{
    public Task<IResult> GetAllProducts(IMediator mediator);
}
