using Ecommar.Catalog.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecommar.Catalog.Shared.DTOs;

public class ProductDto
{
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

    public List<string> ImageUrls { get; set; } = new List<string>();

    public List<ProductReviewDto>? Reviews { get; set; }

    public List<ProductSpecificationDto>? Specifications { get; set; }
}

public class ProductReviewDto
{
    [Required]
    public string? UserId { get; set; }

    [Required]
    [MaxLength(1000)]
    public string? Text { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }
}

public class ProductSpecificationDto
{
    public string? Name { get; set; }
    public string? Value { get; set; }
}