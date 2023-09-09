using Ecommar.Catalog.Models.DTOs;
using Ecommar.Catalog.Services;
using Ecommar.Catalog.Services.Interfaces;

namespace Ecommar.Catalog.API.EndpointsDefinitions;

public class CatalolgEndpointsDefinition
{
    private readonly string _allowedOrigins;
    private readonly IServiceProvider _serviceProvider;

    public CatalolgEndpointsDefinition(WebApplication app, string allowedOrigins)
    {
        _allowedOrigins = allowedOrigins;
        _serviceProvider = app.Services.GetRequiredService<IServiceProvider>();
    }

    public void DefineCatalogEndpoints(WebApplication app)
    {
        using var scope = _serviceProvider.CreateScope();
        ICatalogService catalogService = scope.ServiceProvider.GetRequiredService<ICatalogService>();


        app.MapGet("/products", catalogService.GetAllProducts)
            //.RequireCors(_allowedOrigins);
            .WithDisplayName("Get All Products")
            .Produces<List<ProductDto>>(200);
        
        app.MapGet("/products/{productId}", catalogService.GetProductById)
            //.RequireCors(_allowedOrigins);
            .WithDisplayName("Get Product By Id")
            .Produces<ProductDto>(200);

        app.MapPost("/products", catalogService.AddProduct)
            //.RequireCors(_allowedOrigins);
            .WithDisplayName("Add product")
            .Produces<string>(200);

    }
}
