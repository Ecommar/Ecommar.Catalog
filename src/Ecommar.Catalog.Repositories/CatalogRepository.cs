using Ecommar.Catalog.Repositories.Interfaces;
using MongoDB.Driver;
using Ardalis.GuardClauses;
using Ecommar.Catalog.Shared.Models;
using Ecommar.Catalog.Shared.Infra;
using Ecommar.Catalog.Shared.DTOs;
using AutoMapper;

namespace Ecommar.Catalog.Repositories;

public class CatalogRepository : ICatalogRepository
{
    private readonly CatalogContext _context;
    private readonly IMapper _mapper;

    public CatalogRepository (CatalogContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<ProductDto>> GetAllProducts()
    {
        try
        {
            var products = await _context.Products.Find(Builders<Product>.Filter.Empty).ToListAsync();
            List<ProductDto> productsDto = _mapper.Map<List<ProductDto>>(products);

            return productsDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<ProductDto> GetProductById(string productId)
    {
        try
        {
            var product = await _context.Products
                                        .Find(Builders<Product>.Filter.Eq(p => p.ProductId, productId))
                                        .FirstOrDefaultAsync();
            ProductDto productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }


    public async Task<string?> AddProduct(ProductDto productDto)
    {
        try
        {
            Product product = _mapper.Map<Product>(productDto);
            await _context.Products.InsertOneAsync(product);

            return product?.ProductId?.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<bool> UpdateProduct(ProductDto updatedProductDto)
    {
        try
        {
            Product updatedProduct = _mapper.Map<Product>(updatedProductDto);
            Guard.Against.Default(updatedProduct.ProductId, nameof(updatedProduct.ProductId));

            var replaceResult = await _context.Products.ReplaceOneAsync(
                Builders<Product>.Filter.Eq(p => p.ProductId, updatedProduct.ProductId),
                updatedProduct
            );

            if (replaceResult.ModifiedCount == 0) return false;

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }


    public async Task<bool> DeleteProduct(string productId)
    {
        try
        {
            var deleteResult = await _context.Products.DeleteOneAsync(Builders<Product>.Filter.Eq(p => p.ProductId, productId));

            if(deleteResult.DeletedCount == 0) return false;

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

}
