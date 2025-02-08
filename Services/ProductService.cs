using Latiendita.Dtos;
using Latiendita.Models;
using Latiendita.Repositories;

namespace Latiendita.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() => await _productRepository.GetProductsAsync();
        public async Task<Product> GetByIdAsync(int id) => await _productRepository.GetProductByIdAsync(id);
        public async Task AddAsync(ProductDto productDto) 
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
            };
            await _productRepository.AddProductAsync(product);
        }
        public async Task UpdateAsync(int id, ProductDto productDto) 
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
            };
            await _productRepository.UpdateProductAsync(id, product);
        }
        
        public async Task DeleteAsync(int id) => await _productRepository.DeleteProductAsync(id);
    }
    
}