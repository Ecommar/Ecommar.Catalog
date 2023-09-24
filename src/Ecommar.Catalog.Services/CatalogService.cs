using Ecommar.Catalog.Services.Interfaces;
using Ecommar.Catalog.Shared.Commands;
using Ecommar.Catalog.Shared.DTOs;
using Ecommar.Catalog.Shared.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Ecommar.Catalog.Services;

public class CatalogService : ICatalogService
{
    public async Task<IResult> GetAllProducts(IMediator mediator)
    {
        try
        {
            GetAllProductsQuery query = new();
            List<ProductDto>? response = await mediator.Send(query);

            if (response == null) return Results.NotFound("No product was found");

            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Results.Problem();
        }
    }

    public async Task<IResult> GetProductById(string productId, IMediator mediator)
    {
        try
        {
            GetProductByIdQuery query = new(productId);
            ProductDto? response = await mediator.Send(query);

            if (response == null) return Results.NotFound("No product was found");

            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Results.Problem("An error occurred while processing your request.");
        }
    }

    public async Task<IResult> AddProduct(ProductDto product, IMediator mediator)
    {
        try
        {
            AddProductCommand command = new(product);
            string? response = await mediator.Send(command);
            if (string.IsNullOrEmpty(response))
                return Results.Problem("An error occurred while processing your request.");

            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Results.Problem("An error occurred while processing your request.");
        }
    }

    public async Task<IResult> UpdateProduct(ProductDto product, IMediator mediator)
    {
        try
        {
            UpdateProductCommand command = new(product);
            bool response = await mediator.Send(command);
            if (!response) return Results.NotFound("No product was found"); 

            return Results.Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Results.Problem("An error occurred while processing your request.");
        }
    }

    public async Task<IResult> DeleteProduct(string productId, IMediator mediator)
    {
        try
        {
            DeleteProductCommand command = new(productId);
            bool response = await mediator.Send(command);
            if (!response) return Results.NotFound("No product was found");

            return Results.Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Results.Problem("An error occurred while processing your request.");
        }
    }
}
