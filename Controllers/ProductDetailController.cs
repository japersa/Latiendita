using Latiendita.Models;
using Microsoft.AspNetCore.Mvc;

namespace Latiendita.Controllers
{
    [ApiController]
    [Route("/api/product-details")]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;
        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductDetails()
        {
            var productDetails = await _productDetailService.GetProductDetails();
            return Ok(productDetails);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchProductDetail([FromQuery] string query)
        {
            var productDetails = await _productDetailService.SearchProductDetails(query);
            return Ok(productDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(int id)
        {
            var productDetail = await _productDetailService.GetProductDetailById(id);
            if (productDetail == null)
            {
                return NotFound($"No product detail found with ID {id}");
            }
            return Ok(productDetail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail([FromBody] ProductDetail productDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _productDetailService.AddProductDetail(productDetail);
            return CreatedAtAction(nameof(GetProductDetailById), new { id = productDetail.Id }, productDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductDetail(int id, [FromBody] ProductDetail productDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productDetail.Id)
            {
                return BadRequest("ID mismatch");
            }
            await _productDetailService.UpdateProductDetail(productDetail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(int id)
        {
            var productDetail = await _productDetailService.GetProductDetailById(id);
            if (productDetail == null)
            {
                return NotFound($"No product detail found with ID {id}");
            }
            await _productDetailService.DeleteProductDetail(id);
            return NoContent();
        }
    }
}
