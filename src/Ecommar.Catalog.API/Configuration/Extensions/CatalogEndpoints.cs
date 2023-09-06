using Ecommar.Catalog.API.EndpointsDefinitions;

namespace Ecommar.Catalog.API.Configuration.Extensions;

public static class CatalogEndpoints
{
    public static void CatalogEndpointsExtension(this WebApplication app, string CORSAllowedOrigins) => new CatalolgEndpointsDefinition(app, CORSAllowedOrigins).DefineCatalogEndpoints(app);
}