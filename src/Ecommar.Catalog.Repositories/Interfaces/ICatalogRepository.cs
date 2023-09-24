using Ecommar.Catalog.Shared.DTOs;

namespace Ecommar.Catalog.Repositories.Interfaces;

public interface ICatalogRepository
{
    public Task<List<ProductDto>> GetAllProducts();
    public Task<ProductDto> GetProductById(string productId);
    public Task<string?> AddProduct(ProductDto product);
    public Task<bool> UpdateProduct(ProductDto updatedProduct);
    public Task<bool> DeleteProduct(string productId);
}
