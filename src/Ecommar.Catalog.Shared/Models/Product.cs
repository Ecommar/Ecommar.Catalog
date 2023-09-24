using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Ecommar.Catalog.Shared.Models;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ProductId { get; set; }

    [Required]
    [MaxLength(255)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public decimal? Price { get; set; }

    [Range(0, int.MaxValue)]
    public int? InventoryCount { get; set; }

    public ProductCategory Category { get; set; }

    public List<string> ImageUrls { get; set; } = new();

    public List<ProductReview>? Reviews { get; set; }

    public List<ProductSpecification>? Specifications { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public enum ProductCategory
{
    // Add your product categories here
    Electronics = 0,
    Clothing = 1,
    HomeGoods = 2,
    // ... other categories ...
}
public class ProductReview
{
    [Required]
    public string? UserId { get; set; }

    [Required]
    [MaxLength(1000)]
    public string? Text { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
}

public class ProductSpecification
{
    public string? Name { get; set; }
    public string? Value { get; set; }
}