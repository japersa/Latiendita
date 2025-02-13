using Latiendita.Data;
using Latiendita.Models;
using Microsoft.EntityFrameworkCore;

namespace Latiendita.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context) => _context = context;

        public async Task CreateOrderAsync(Order order)
        {
            var product = await _context.Products.FindAsync(order.ProductId);
            if (product == null)
                throw new KeyNotFoundException("Producto no encontrado");

            if (product.Stock < order.Quantity)
                throw new InvalidOperationException("Stock insuficiente");

            product.Stock -= order.Quantity;  // Se descuenta del inventario
            _context.Orders.Add(order);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await _context.Orders
                .FirstOrDefaultAsync(pd => pd.Id == id)
                ?? throw new KeyNotFoundException($"Order with ID {id} not found.");
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders.Include(o => o.Product).ToListAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(order.Id)
                ?? throw new KeyNotFoundException($"Order with ID {order.Id} not found.");

            if (existingOrder.ProductId != order.ProductId || existingOrder.Quantity != order.Quantity)
            {
                existingOrder.ProductId = order.ProductId;
                existingOrder.Quantity = order.Quantity;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreatePurchaseAsync(int productId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new KeyNotFoundException("Producto no encontrado");

            product.Stock += quantity;  // Se incrementa el inventario
            await _context.SaveChangesAsync();
        }
    }
}

