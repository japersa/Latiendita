using Latiendita.Dtos;
using Latiendita.Models;
using Latiendita.Repositories;

namespace AppProducts.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<(IEnumerable<Product> items, int totalItems, int totalPages)> GetAllProductsAsync(int page, int size) => await _productRepository.GetAllAsync(page, size);
        public async Task<Product?> GetByIdAsync(int id) => await _productRepository.GetByIdAsync(id);
        public async Task AddAsync(ProductDto productDto) 
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
                ProductDetail = productDto.ProductDetail != null ? new ProductDetail
                {
                    Image = productDto.ProductDetail.Image,
                    Description = productDto.ProductDetail.Description,
                    Stock = productDto.ProductDetail.Stock,
                    Weight = productDto.ProductDetail.Weight,
                    Dimensions = productDto.ProductDetail.Dimensions
                } : null
            };
            await _productRepository.AddAsync(product);
        }
        public async Task UpdateAsync(int id, ProductDto productDto) 
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
                ProductDetail = new ProductDetail
                {
                    Image = productDto.ProductDetail.Image,
                    Description = productDto.ProductDetail.Description,
                    Stock = productDto.ProductDetail.Stock,
                    Weight = productDto.ProductDetail.Weight,
                    Dimensions = productDto.ProductDetail.Dimensions
                }
            };
            await _productRepository.UpdateAsync(id, product);
        }
        
        public async Task DeleteAsync(int id) => await _productRepository.DeleteAsync(id);
    }
    
}