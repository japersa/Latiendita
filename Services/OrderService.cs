using Latiendita.Models;
using Latiendita.Dtos;
using Latiendita.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Latiendita.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

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

            if (orderDto.Quantity <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor que cero.");
            }

            product.Stock += orderDto.Quantity;

            var order = new Order
            {
                ProductId = orderDto.ProductId,
                Product = product,
                Quantity = orderDto.Quantity
            };

            await _orderRepository.CreateOrderAsync(order);
            await _productRepository.UpdateProductStockAsync(product);
        }

        public async Task UpdateOrderAsync(int id, OrderDto orderDto)
        {
            var product = await _productRepository.GetByIdAsync(orderDto.ProductId);
            if (product == null) throw new Exception("Producto no encontrado");

            var existingOrder = await _orderRepository.GetOrderAsync(id);
            if (existingOrder == null) throw new KeyNotFoundException($"Orden con ID {id} no encontrada");

            if (orderDto.Quantity <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor que cero.");
            }

            // ? Revertir la cantidad anterior antes de actualizar
            product.Stock -= existingOrder.Quantity;

            // ? Agregar la nueva cantidad
            product.Stock += orderDto.Quantity;

            var updatedOrder = new Order
            {
                Id = id,
                ProductId = orderDto.ProductId,
                Product = product,
                Quantity = orderDto.Quantity
            };

            await _orderRepository.UpdateOrderAsync(updatedOrder);
            await _productRepository.UpdateProductStockAsync(product);
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _orderRepository.GetOrderAsync(id);
            if (order == null) throw new KeyNotFoundException($"Orden con ID {id} no encontrada");

            var product = await _productRepository.GetByIdAsync(order.ProductId);
            if (product == null) throw new Exception("Producto no encontrado");

            // ? Revertir el stock al eliminar la orden
            product.Stock -= order.Quantity;

            await _orderRepository.DeleteOrderAsync(id);
            await _productRepository.UpdateProductStockAsync(product);
        }
    }
}
