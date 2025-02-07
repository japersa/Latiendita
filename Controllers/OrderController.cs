<<<<<<< HEAD
﻿using Latiendita.Dtos;
using Latiendita.Services;
=======
using Latiendita.Models;
>>>>>>> origin/main
using Microsoft.AspNetCore.Mvc;

namespace Latiendita.Controllers
{
    [ApiController]
<<<<<<< HEAD
    [Route("api/order")]
    public class OrdenCompraController : ControllerBase
    {
        private readonly IOrderService _ordenCompraService;

        public OrdenCompraController(IOrderService ordenCompraService)
        {
            _ordenCompraService = ordenCompraService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _ordenCompraService.GetAllOrdersAsync();
=======
    [Route("/api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetOrders();
>>>>>>> origin/main
            return Ok(orders);
        }

        [HttpGet("{id}")]
<<<<<<< HEAD
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _ordenCompraService.GetOrderByIdAsync(id);
            if (order == null) return NotFound();
=======
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound($"No order found with ID {id}");
            }
>>>>>>> origin/main
            return Ok(order);
        }

        [HttpPost]
<<<<<<< HEAD
        public async Task<IActionResult> Create(OrderDto OrderDto)
        {
            await _ordenCompraService.CreateOrderAsync(OrderDto);
            return CreatedAtAction(nameof(GetById), new { id = OrderDto.Id }, OrderDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderDto OrderDto)
        {
            await _ordenCompraService.UpdateOrderAsync(id, OrderDto);
            return Ok(OrderDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ordenCompraService.DeleteOrderAsync(id);
            return Ok();
        }
    }
}
=======
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _orderService.GetProductById(order.ProductId);
            if (product == null)
            {
                return NotFound($"No product found with ID {order.ProductId}");
            }

            if (product.ProductDetail != null && order.Quantity > product.ProductDetail.Stock)
            {
                return BadRequest("Insufficient stock for this order.");
            }

            await _orderService.AddOrder(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Id)
            {
                return BadRequest("ID mismatch");
            }

            await _orderService.UpdateOrder(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound($"No order found with ID {id}");
            }
            await _orderService.DeleteOrder(id);
            return NoContent();
        }
    }
}
>>>>>>> origin/main
