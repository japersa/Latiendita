using Latiendita.Models;

namespace Latiendita.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(int Id,Product product);
        Task DeleteProductAsync(int Id);
    }
}