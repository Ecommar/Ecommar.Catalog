using Ecommar.Catalog.Models.Commands;
using Ecommar.Catalog.Models.DTOs;
using Ecommar.Catalog.Models.Queries;
using Ecommar.Catalog.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ecommar.Catalog.Services;

public class CatalogService : ICatalogService
{
    public async Task<IResult> GetAllProducts(IMediator mediator)
    {
        List<ProductDto>? response;

        try
        {
            GetAllProductsQuery query = new();
            response = await mediator.Send(query);

            if (response == null)
            {
                return Results.NotFound();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Results.Problem();
        }

        return Results.Ok(response);
    }

    public async Task<IResult> GetProductById(string productId, IMediator mediator)
    {
        ProductDto? response;

        try
        {
            GetProductByIdQuery query = new(productId);
            response = await mediator.Send(query);

            if (response == null)
            {
                return Results.NotFound();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Results.Problem();
        }

        return Results.Ok(response);
    }

    public async Task<IResult> AddProduct(ProductDto product, IMediator mediator)
    {
        string response;

        try
        {
            AddProductCommand command = new(product);
            response = await mediator.Send(command);

            if (string.IsNullOrEmpty(response))
            {
                return Results.Problem("Unable to create the product.", statusCode: 500);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Results.Problem("An error occurred while processing your request.", statusCode: 500);
        }

        return Results.Ok(response);

    }
}
