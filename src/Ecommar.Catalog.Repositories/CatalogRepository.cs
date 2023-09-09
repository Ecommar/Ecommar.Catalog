using Ecommar.Catalog.Models.DTOs;
using Ecommar.Catalog.Repositories.Interfaces;

namespace Ecommar.Catalog.Repositories;

public class CatalogRepository : ICatalogRepository
{
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

        return Task.FromResult(products);
    }

    public Task<ProductDto> GetProductById(string productId)
    {
        var product = new ProductDto
        {
            Id = productId,
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
        };

        return Task.FromResult(product);
    }
}
