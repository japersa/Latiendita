using Latiendita.Dtos;
using Latiendita.Models;
using Latiendita.Repositories;

namespace Latiendita.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category?> GetCategoryByIdAsync(int id) => await _categoryRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Category>> GetCategoriesAsync() => await _categoryRepository.GetAllAsync();
        
        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
            };

            await _categoryRepository.AddAsync(category);
        }
       
       public async Task UpdateCategoryAsync(int id, CategoryDto categoryDto)
       {
           var category = new Category
           {
               Name = categoryDto.Name
           };

           await _categoryRepository.UpdateAsync(id, category);
       }

       public async Task DeleteCategoryAsync(int id) => await _categoryRepository.DeleteAsync(id);

    }
}