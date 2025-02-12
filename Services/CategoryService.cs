using Latiendita.Dtos;
using Latiendita.Models;
using Latiendita.Repositories;

namespace Latiendita.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<Category?> GetCategoryByIdAsync(int id) => await _categoryRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Category>> GetCategoriesAsync() => await _categoryRepository.GetAllAsync();
        
        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            _logger.LogInformation("***********Adding a new category*******");
            var category = new Category
            {
                Name = categoryDto.Name,
            };
            try
            {
                await _categoryRepository.AddAsync(category);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error adding a new category");
            } 
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

        public async Task<IEnumerable<CategoryDto>> GetForCategoryAsync(string categoryDto)
        {
            var categories = await _categoryRepository.GetForCategoryAsync(categoryDto);
            return categories.Select(c => new CategoryDto { Id = c.Id,Name = c.Name });
        }
    }
}