using Latiendita.Dtos;
using Latiendita.Models;

namespace AppProducts.Services
{
    public interface IProductService
    {
        Task<(IEnumerable<Product> items, int totalItems, int totalPages)> GetAllProductsAsync(int page, int size);
        Task<Product?> GetByIdAsync(int id);
        Task AddProductAsync(ProductDto productDto);
        Task UpdateProductAsync(int id, ProductDto productDto);
        Task DeleteProductAsync(int id);
    }
}