using Latiendita.Models;
using Latiendita.Dtos;
using Latiendita.Repositories;

namespace Latiendita.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository; // Agregado para obtener el producto

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
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
            var product = await _productRepository.GetByIdAsync(orderDto.ProductId);
            if (product == null) throw new Exception("Producto no encontrado");

            var order = new Order
            {
                ProductId = orderDto.ProductId,
                Product = product, // Se inicializa correctamente
                Quantity = orderDto.Quantity
            };
            await _orderRepository.CreateOrderAsync(order);  
        }

        public async Task UpdateOrderAsync(int id, OrderDto orderDto)
        {
            var product = await _productRepository.GetByIdAsync(orderDto.ProductId);
            if (product == null) throw new Exception("Producto no encontrado");

            var order = new Order
            {
                Id = id,
                ProductId = orderDto.ProductId,
                Product = product, // Se inicializa correctamente
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
