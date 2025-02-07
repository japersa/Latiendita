<<<<<<< HEAD
﻿using Latiendita.Dtos;
using Latiendita.Services;
=======
﻿using Latiendita.Models;
>>>>>>> origin/main
using Microsoft.AspNetCore.Mvc;

namespace Latiendita.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
<<<<<<< HEAD

=======
>>>>>>> origin/main
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
<<<<<<< HEAD
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
=======
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCategory([FromQuery] string query)
        {
            var categories = await _categoryService.SearchCategories(query);
>>>>>>> origin/main
            return Ok(categories);
        }

        [HttpGet("{id}")]
<<<<<<< HEAD
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
=======
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound($"No category found with ID {id}");
>>>>>>> origin/main
            }
            return Ok(category);
        }

        [HttpPost]
<<<<<<< HEAD
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryService.AddCategoryAsync(categoryDto);
            return CreatedAtAction(nameof(GetById), new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryDto categoryDto)
        {
            await _categoryService.UpdateCategoryAsync(id, categoryDto);
            return Ok(categoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok();
=======
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _categoryService.AddCategory(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.Id)
            {
                return BadRequest("ID mismatch");
            }
            await _categoryService.UpdateCategory(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound($"No category found with ID {id}");
            }
            await _categoryService.DeleteCategory(id);
            return NoContent();
>>>>>>> origin/main
        }
    }
}
