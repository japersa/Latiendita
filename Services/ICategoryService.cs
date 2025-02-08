using Latiendita.Dtos;
using Latiendita.Models;

namespace Latiendita.Services
{
    public interface ICategoryService
    {
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task AddCategoryAsync(CategoryDto categoryDto);
        Task UpdateCategoryAsync(int id, CategoryDto categoryDto);
        Task DeleteCategoryAsync(int id);
    }
}