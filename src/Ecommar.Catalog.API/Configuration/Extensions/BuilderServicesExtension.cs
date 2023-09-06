using Ecommar.Catalog.Repositories;
using Ecommar.Catalog.Repositories.Interfaces;
using Ecommar.Catalog.Services;
using Ecommar.Catalog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace Ecommar.Catalog.API.Configuration.Extensions;
public static class BuilderServicesExtension
{
    /// <summary>
    /// AddSwagger
    /// </summary>
    /// <param name="builder"></param>
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
            .AddScoped<ICatalogService, CatalogService>();
    }

    public static void AddAndConfigureResponseCaching(this WebApplicationBuilder builder)
    {
        builder.Services.AddResponseCaching(options =>
        {
            options.MaximumBodySize = 1024;
            options.UseCaseSensitivePaths = true;
        });
    }


    /// <summary>
    /// AddAndConfigureMediator
    /// </summary>
    /// <param name="builder"></param>
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
}
