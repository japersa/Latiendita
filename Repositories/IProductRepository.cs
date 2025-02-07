using Latiendita.Models;

namespace Latiendita.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(int Id,Product product);
        Task DeleteAsync(int Id);
    }
}