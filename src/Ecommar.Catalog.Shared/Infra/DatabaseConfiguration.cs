using Microsoft.Extensions.Configuration;

namespace Ecommar.Catalog.Shared.Infra
{
    public class DatabaseConfiguration
    {
        private readonly IConfiguration _configuration;

        public DatabaseConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? GetMongoDBConnectionString()
        {
            return _configuration.GetConnectionString("MongoDBConnection");
        }
    }
}
