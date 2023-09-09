using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Ecommar.Catalog.Infra
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
