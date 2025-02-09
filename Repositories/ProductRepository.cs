using Latiendita.Data;
using Latiendita.Models;
using Microsoft.EntityFrameworkCore;

namespace Latiendita.Repositories
{
        public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found");
            }
            return product;
        }

        public async Task AddProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(int id, Product product)
        {
           
            if (id <= 0)
            {
            throw new ArgumentException("El ID del producto debe ser mayor que 0.");
            }//se agrega condicion para que el ID no sea igual o menor que 0.

            var existingProduct = await GetProductByIdAsync(id);

            if (existingProduct == null)
            {
            throw new KeyNotFoundException($"El producto con ID {id} no existe.");
            }

            if (product == null)
            {
            throw new ArgumentNullException(nameof(product));
            }

            if (id != product.Id)
            {
                throw new ArgumentException($"El ID del producto en la URL ({id}) no coincide con el ID en el cuerpo ({product.Id}).");
            }

            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> SearchAsync(string query)
        {
            return await _context.Products
                .Where(p => p.Name.Contains(query))
                .ToListAsync();
        }

        public async Task<(IEnumerable<Product> items, int totalItems, int totalPages)> GetAllAsync(int page, int size)
        {
            if (page <= 0 || size <= 0)
            {
                throw new ArgumentException("Page and size must be greater than zero.");
            }

            var totalItems = await _context.Products.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)size);

            var items = await _context.Products
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            return (items, totalItems, totalPages);
        }

        public Task<Product> GetByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
