using Latiendita.Models;

namespace Latiendita.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);

        Task AddProductAsync(Product product);
        Task UpdateProductAsync(int Id,Product product);
        Task DeleteProductAsync(int Id);
        Task<IEnumerable<Product>> SearchAsync(string query);
    }

}
