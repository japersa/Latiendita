using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using Latiendita.Data;
using Latiendita.Models;
using Microsoft.EntityFrameworkCore;
 
namespace Latiendita.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
 
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
 
        public Task CreateOrderAsync(Order order)
        {
           _context.Orders.Add(order);
            return _context.SaveChangesAsync();
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
 
        public async Task<Order?> GetOrderAsync(int id)
        {
            return await _context.Orders
               .FirstOrDefaultAsync(pd => pd.Id == id);
        }
 
        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders.Include(o=>o.Product).ToListAsync();
        }

 
     public async Task UpdateOrderAsync(Order order)
    {
       var existingOrder = await _context.Orders.FindAsync(order.Id);
       if (existingOrder != null)
        {
        existingOrder.ProductId = order.ProductId;
        existingOrder.Quantity = order.Quantity;
        await _context.SaveChangesAsync();
          }
        }
        }
    }
