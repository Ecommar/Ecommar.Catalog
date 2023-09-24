using Ecommar.Catalog.Shared.Models;
using MongoDB.Driver;

namespace Ecommar.Catalog.Shared.Infra;

public class CatalogContext
{
    private readonly IMongoDatabase _database;

    public CatalogContext(IMongoClient client, string databaseName)
    {
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
}
