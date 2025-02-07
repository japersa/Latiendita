using Latiendita.Dtos;
using Latiendita.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Latiendita.Controllers
{
    [ApiController]
    [Route("api/sale")]
    public class FacturaVentaController : ControllerBase
    {
        private readonly IFacturaVentaService _facturaVentaService;

        public FacturaVentaController(IFacturaVentaService facturaVentaService)
        {
            _facturaVentaService = facturaVentaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoices = await _facturaVentaService.GetAllInvoicesAsync();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invoice = await _facturaVentaService.GetByIdAsync(id);
            if (invoice == null) return NotFound();
            return Ok(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FacturaVentaDto facturaVentaDto)
        {
            await _facturaVentaService.AddInvoiceAsync(facturaVentaDto);
            return CreatedAtAction(nameof(GetById), new { id = facturaVentaDto.Id }, facturaVentaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FacturaVentaDto facturaVentaDto)
        {
            await _facturaVentaService.UpdateInvoiceAsync(id, facturaVentaDto);
            return Ok(facturaVentaDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _facturaVentaService.DeleteInvoiceAsync(id);
            return Ok();
        }
    }
}
