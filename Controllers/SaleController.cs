using Latiendita.Models;
using Microsoft.AspNetCore.Mvc;

namespace Latiendita.Controllers
{
    [ApiController]
    [Route("/api/sales")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSales()
        {
            var sales = await _saleService.GetSales();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSaleById(int id)
        {
            var sale = await _saleService.GetSaleById(id);
            if (sale == null)
            {
                return NotFound($"No sale found with ID {id}");
            }
            return Ok(sale);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _saleService.GetProductById(sale.ProductId);
            if (product == null)
            {
                return NotFound($"No product found with ID {sale.ProductId}");
            }

            if (product.ProductDetail != null && sale.Quantity > product.ProductDetail.Stock)
            {
                return BadRequest("Insufficient stock for this sale.");
            }

            await _saleService.AddSale(sale);
            return CreatedAtAction(nameof(GetSaleById), new { id = sale.Id }, sale);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSale(int id, [FromBody] Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sale.Id)
            {
                return BadRequest("ID mismatch");
            }

            await _saleService.UpdateSale(sale);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            var sale = await _saleService.GetSaleById(id);
            if (sale == null)
            {
                return NotFound($"No sale found with ID {id}");
            }
            await _saleService.DeleteSale(id);
            return NoContent();
        }
    }
}