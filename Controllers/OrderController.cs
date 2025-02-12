using Latiendita.Dtos;
using Latiendita.Services;
using Microsoft.AspNetCore.Mvc;

namespace Latiendita.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

       [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDto orderDto)
        {
        await _orderService.CreateOrderAsync(orderDto);
        return Ok(new { message = "Orden creada correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderDto OrderDto)
        {
            await _orderService.UpdateOrderAsync(id, OrderDto);
            return Ok(OrderDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return Ok();
        }
    }
}
