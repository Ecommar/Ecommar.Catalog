namespace Ecommar.Catalog.Models.DTOs;

public class ProductDto
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public int? StockCount { get; set; }
    public string? Category { get; set; }
    public List<string>? Images { get; set; }
    public List<ProductReview>? Reviews { get; set; }
    public List<ProductAttribute>? Attributes { get; set; }
}

public class ProductReview
{
    public string? ReviewId { get; set; }
    public string? Text { get; set; }
    public int Rating { get; set; }
    public DateTime Date { get; set; }
}

public class ProductAttribute
{
    public string? AttributeId { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }
}