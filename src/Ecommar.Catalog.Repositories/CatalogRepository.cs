using Ecommar.Catalog.Models.DTOs;
using Ecommar.Catalog.Repositories.Interfaces;
using System;
using Ecommar.Catalog.Infra;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ecommar.Catalog.Repositories;

public class CatalogRepository : ICatalogRepository
{
    private readonly DatabaseConfiguration _databaseConfiguration;


    public CatalogRepository (DatabaseConfiguration databaseConfiguration)
    {
        _databaseConfiguration = databaseConfiguration;
    }
    public Task<List<ProductDto>> GetAllProducts()
    {
        // In a real-world scenario, you'd fetch this from a database.
        List<ProductDto>? products = new()
        {
            new ProductDto
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Smartphone",
                Description = "High-end smartphone with advanced features.",
                Price = 799.99m,
                StockCount = 50,
                Category = "Electronics",
                Images = new List<string> { "https://example.com/image1.jpg", "https://example.com/image2.jpg" },
                Reviews = new List<ProductReview>
                {
                    new ProductReview
                    {
                        ReviewId = Guid.NewGuid().ToString(),
                        Text = "Excellent smartphone, great camera!",
                        Rating = 5,
                        Date = DateTime.Now.AddDays(-15)
                    },
                    new ProductReview
                    {
                        ReviewId = Guid.NewGuid().ToString(),
                        Text = "Battery life could be better, but overall a solid device.",
                        Rating = 4,
                        Date = DateTime.Now.AddDays(-10)
                    }
                },
                Attributes = new List<ProductAttribute>
                {
                    new ProductAttribute
                    {
                        AttributeId = Guid.NewGuid().ToString(),
                        Name = "Color",
                        Value = "Black"
                    },
                    new ProductAttribute
                    {
                        AttributeId = Guid.NewGuid().ToString(),
                        Name = "Storage",
                        Value = "128GB"
                    }
                }
            }
        };
        string? connectionString = _databaseConfiguration.GetMongoDBConnectionString();
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("test");

        // Specify the name of the collection (table)
        string collectionName = "your-collection-name";

        // Create a new collection (table) in MongoDB if it doesn't exist
        var collection = database.GetCollection<BsonDocument>(collectionName);
        collection.Indexes.CreateOne(new CreateIndexModel<BsonDocument>(Builders<BsonDocument>.IndexKeys.Ascending("_id")));

        // Attempt to retrieve the collection's statistics to check if it exists
        var collectionStats = database.RunCommand<BsonDocument>(new BsonDocument { { "collStats", collectionName } });

        bool isCollectionCreated = collectionStats.Contains("ok");

        if (isCollectionCreated)
        {
            var res = true; // Connection successful
        }
        else
        {
            var res = false; // Connection failed
        }
        return Task.FromResult(products);
    }
}
