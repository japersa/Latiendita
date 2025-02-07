<<<<<<< HEAD
﻿using Latiendita.Dtos;
using Latiendita.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
=======
using Latiendita.Models;
using Microsoft.AspNetCore.Mvc;
>>>>>>> origin/main

namespace Latiendita.Controllers
{
    [ApiController]
<<<<<<< HEAD
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
=======
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
>>>>>>> origin/main
