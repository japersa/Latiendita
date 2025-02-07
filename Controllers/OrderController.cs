using Latiendita.Dtos;
using Latiendita.Services;
using Microsoft.AspNetCore.Mvc;

namespace Latiendita.Controllers
{
    [ApiController]
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
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _ordenCompraService.GetOrderByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
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
