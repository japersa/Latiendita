using Latiendita.Dtos;
using Latiendita.Models;
using Latiendita.Repositories;

namespace Latiendita.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository; // Agregado para obtener categoría

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() => await _productRepository.GetProductsAsync();
        public async Task<Product> GetByIdAsync(int id) => await _productRepository.GetProductByIdAsync(id);

        public async Task AddAsync(ProductDto productDto)
        {
            var category = await _categoryRepository.GetByIdAsync(productDto.CategoryId);
            if (category == null) throw new Exception("Categoría no encontrada");

            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
                Category = category, // Se obtiene de la BD
                ProductDetail = productDto.ProductDetail != null
    ? new ProductDetail
    {
        Name = productDto.ProductDetail.Name,
        Image = productDto.ProductDetail.Image,
        Description = productDto.ProductDetail.Description,
        Stock = productDto.ProductDetail.Stock,
        Weight = productDto.ProductDetail.Weight,
        Dimensions = productDto.ProductDetail.Dimensions,
        Category = category
    }
    : new ProductDetail { Name = productDto.Name, Category = category }
            };


            await _productRepository.AddProductAsync(product);
        }

        public async Task UpdateAsync(int id, ProductDto productDto)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(id);
            if (existingProduct == null) throw new Exception("Producto no encontrado");

            existingProduct.Name = productDto.Name;
            existingProduct.Price = productDto.Price;
            existingProduct.CategoryId = productDto.CategoryId;
            existingProduct.Stock = productDto.Stock; // se actualiza Stock

            if (productDto.ProductDetail != null && existingProduct.ProductDetail != null)
            {
                existingProduct.ProductDetail.Name = productDto.ProductDetail.Name;
                existingProduct.ProductDetail.Image = productDto.ProductDetail.Image;
                existingProduct.ProductDetail.Description = productDto.ProductDetail.Description;
                existingProduct.ProductDetail.Stock = productDto.ProductDetail.Stock; // se actualiza Stock en ProductDetail
                existingProduct.ProductDetail.Weight = productDto.ProductDetail.Weight;
                existingProduct.ProductDetail.Dimensions = productDto.ProductDetail.Dimensions;
            }

            await _productRepository.UpdateProductAsync(id, existingProduct);
        }


        public async Task DeleteAsync(int id) => await _productRepository.DeleteProductAsync(id);
    }
}
