using Ecommar.Catalog.Models.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Ecommar.Catalog.Services.Interfaces;

public interface ICatalogService
{
    public Task<IResult> GetAllProducts(IMediator mediator);
    public Task<IResult> GetProductById(string productId, IMediator mediator);

    public Task<IResult> AddProduct(ProductDto product, IMediator mediator);
}
