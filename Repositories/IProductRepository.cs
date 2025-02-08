using Latiendita.Models;

namespace Latiendita.Repositories
{
    public interface IProductRepository
    {
        Task<(IEnumerable<Product> items, int totalItems, int totalPages)> GetAllAsync(int page, int size);
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(int Id,Product product);
        Task DeleteProductAsync(int Id);
        Task<IEnumerable<Product>> SearchAsync(string query);
    }

   
