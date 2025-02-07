using Latiendita.Models;
using Latiendita.Dtos;
using Latiendita.Repositories;

namespace Latiendita.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetOrdersAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetOrderAsync(id);
        }

        public async Task CreateOrderAsync(OrderDto orderDto)
        {
            var order = new Order
            {
                ProductId = orderDto.ProductId,
                Quantity = orderDto.Quantity
            };
            await _orderRepository.CreateOrderAsync(order);
        }

        public async Task UpdateOrderAsync(int id, OrderDto orderDto)
        {
            var order = new Order
            {
                Id = id,
                ProductId = orderDto.ProductId,
                Quantity = orderDto.Quantity
            };
            await _orderRepository.UpdateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteOrderAsync(id);
        }
    }
}
