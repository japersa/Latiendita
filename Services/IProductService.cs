using Latiendita.Dtos;
using Latiendita.Models;

namespace Latiendita.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(ProductDto productDto);
        Task UpdateAsync(int Id, ProductDto productDto);
        Task DeleteAsync(int Id);
    }
}