using Latiendita.Models;
using Latiendita.Dtos;

namespace Latiendita.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(OrderDto orderDto);
        Task UpdateOrderAsync(int id, OrderDto orderDto);
        Task DeleteOrderAsync(int id);
    }
}
