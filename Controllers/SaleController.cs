using Latiendita.Dtos;
using Latiendita.Services;
using Microsoft.AspNetCore.Mvc;

namespace Latiendita.Controllers
{
    [ApiController]
    [Route("api/sale")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoices = await _saleService.GetAllSalesAsync();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invoice = await _saleService.GetSaleByIdAsync(id);
            if (invoice == null) return NotFound();
            return Ok(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaleDto saleDto)
        {
            await _saleService.CreateSaleAsync(saleDto);
            return CreatedAtAction(nameof(GetById), new { id = saleDto.Id }, saleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SaleDto saleDto)
        {
            await _saleService.UpdateSaleAsync(id, saleDto);
            return Ok(saleDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _saleService.DeleteSaleAsync(id);
            return Ok();
        }
    }
}


