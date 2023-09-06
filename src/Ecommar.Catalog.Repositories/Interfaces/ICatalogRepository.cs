using Ecommar.Catalog.Models.DTOs;

namespace Ecommar.Catalog.Repositories.Interfaces;

public interface ICatalogRepository
{
    public Task<List<ProductDto>> GetAllProducts();
}
