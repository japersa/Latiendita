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
        public async Task<IActionResult> Create([FromBody]OrderDto OrderDto)
        {
            await _orderService.CreateOrderAsync(OrderDto);
            return CreatedAtAction(nameof(GetById), new { id = OrderDto.Id }, OrderDto);
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
