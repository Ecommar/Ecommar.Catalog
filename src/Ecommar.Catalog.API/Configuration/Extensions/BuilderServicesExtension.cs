using Ecommar.Catalog.Repositories;
using Ecommar.Catalog.Repositories.Interfaces;
using Ecommar.Catalog.Services;
using Ecommar.Catalog.Services.Interfaces;
using Ecommar.Catalog.Shared.Infra;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Reflection;

namespace Ecommar.Catalog.API.Configuration.Extensions;
public static class BuilderServicesExtension
{
    public static void AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the bearer scheme",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement() { {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Id    = "Bearer",
                    Type  = ReferenceType.SecurityScheme
                }
            }, new List<string>() }
        });
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Catalog API"
            });
        });
    }

    public static void AddScopedIoc(this WebApplicationBuilder builder)
    {
        //var configuration = builder.Configuration;
        builder.Services
            //.AddMemoryCache()
            .AddScoped<ICatalogRepository, CatalogRepository>()
            .AddScoped<ICatalogService, CatalogService>()
            .AddScoped<DatabaseConfiguration>();

    }

    public static void AddAndConfigureResponseCaching(this WebApplicationBuilder builder)
    {
        builder.Services.AddResponseCaching(options =>
        {
            options.MaximumBodySize = 1024;
            options.UseCaseSensitivePaths = true;
        });
    }

    public static void AddAndConfigureMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly(),
                Assembly.Load("Ecommar.Catalog.Mediator")
            );
        });
    }

    public static void AddMongoServices(this WebApplicationBuilder builder)
    {
        var mongoSettings = new MongoSettings();
        builder.Configuration.GetSection("MongoSettings").Bind(mongoSettings);

        // Add MongoSettings to DI
        builder.Services.AddSingleton(mongoSettings);

        // Add MongoDB Client and CatalogContext to DI
        builder.Services.AddSingleton<IMongoClient>(sp =>
        {
            return new MongoClient(mongoSettings.ConnectionString);
        });

        builder.Services.AddSingleton(sp =>
        {
            var settings = sp.GetRequiredService<MongoSettings>();
            var client = sp.GetRequiredService<IMongoClient>();
            return new CatalogContext(client, settings.DatabaseName!);
        });
    }

    public static void AddAutoMapperConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(assembly =>
        {
            assembly.AddMaps(typeof(Shared.Mappers.MappingProfile).Assembly);
        });
    }

}
