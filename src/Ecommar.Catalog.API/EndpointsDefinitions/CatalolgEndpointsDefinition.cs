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
            .WithDisplayName("Get All Products")
            .Produces<List<ProductDto>>(200);
            //.RequireCors(_allowedOrigins);
    }
}
