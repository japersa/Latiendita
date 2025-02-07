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
    [Route("/api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
<<<<<<< HEAD

=======
>>>>>>> origin/main
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
<<<<<<< HEAD
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            var (items, totalItems, totalPages) = await _productService.GetAllProductsAsync(page, size);
            return Ok(new { items, totalItems, totalPages });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
=======
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchProduct([FromQuery] string query)
        {
            var products = await _productService.SearchProducts(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound($"No product found with ID {id}");
>>>>>>> origin/main
            }
            return Ok(product);
        }

        [HttpPost]
<<<<<<< HEAD
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            await _productService.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetById), new { id = productDto.Id }, productDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDto productDto)
        {
            await _productService.UpdateProductAsync(id, productDto);
            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok();
=======
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest("ID mismatch");
            }
            await _productService.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound($"No product found with ID {id}");
            }
            await _productService.DeleteProduct(id);
            return NoContent();
>>>>>>> origin/main
        }
    }
}
