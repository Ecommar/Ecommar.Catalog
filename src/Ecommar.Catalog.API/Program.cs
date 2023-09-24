using Ecommar.Catalog.API.Configuration.Extensions;

try
{
    const string corsAllowedOrigins = "CORSAllowedOrigins";
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddEndpointsApiExplorer();
    builder.AddAndConfigureResponseCaching();
    builder.AddSwagger();
    builder.AddScopedIoc();
    builder.AddAndConfigureMediator();
    builder.AddMongoServices();
    builder.AddAutoMapperConfiguration();

    var app = builder.Build();
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.UseResponseCaching();

    app.Logger.LogInformation("end points configuration!");
    app.CatalogEndpointsExtension(corsAllowedOrigins);
    app.Logger.LogInformation("Start the server");

    app.Run();
}
catch (Exception exception)
{
    Console.WriteLine(exception.Message, "Application terminated unexpectedly");
}
finally
{
    Console.WriteLine("finally");
}