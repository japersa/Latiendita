using Latiendita.Repositories;
using Latiendita.Models;
using Latiendita.Dtos;

namespace Latiendita.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;

        public SaleService(ISaleRepository saleRepository, IProductRepository productRepository)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync()
        {
            return await _saleRepository.GetSalesAsync();
        }

        public async Task<Sale?> GetSaleByIdAsync(int id)
        {
            return await _saleRepository.GetSaleByIdAsync(id);
        }

        public async Task CreateSaleAsync(SaleDto saleDto)
        {
            var product = await _productRepository.GetByIdAsync(saleDto.ProductId);
            if (product == null)
                throw new Exception("Producto no encontrado");

            if (product.ProductDetail.Stock < saleDto.Quantity)
                throw new Exception("Stock insuficiente para la venta");

            var sale = new Sale
            {
                Quantity = saleDto.Quantity,
                ProductId = saleDto.ProductId, // Se asigna el ProductId
                Product = product              // Se asigna el producto
            };

            product.ProductDetail.Stock = product.ProductDetail.Stock - saleDto.Quantity;

            await _productRepository.UpdateProductStockAsync(product);

            await _saleRepository.AddSaleAsync(sale);
        }

        public async Task UpdateSaleAsync(int id, SaleDto saleDto)
        {

            var Searchsale = await _saleRepository.GetSaleByIdAsync(id);
            if (Searchsale == null)
                throw new Exception("Venta no encontrada");

            var product = await _productRepository.GetByIdAsync(saleDto.ProductId);
            if (product == null)
                throw new Exception("Producto no encontrado");

            var CalculationQuantity = saleDto.Quantity - Searchsale.Quantity;

            if (product.ProductDetail.Stock < CalculationQuantity)
                throw new Exception("Stock insuficiente para la venta");

            Searchsale.Quantity = saleDto.Quantity;

            product.ProductDetail.Stock = product.ProductDetail.Stock - CalculationQuantity;


            var sale = new Sale
            {
                Id = id,
                Quantity = saleDto.Quantity,
                ProductId = saleDto.ProductId, // Se asigna el ProductId
                Product = product              // Se asigna el producto
            };

            await _saleRepository.UpdateSaleAsync(id, sale);
            await _productRepository.UpdateProductStockAsync(product);
        }

        public async Task DeleteSaleAsync(int id)
        {

            var Searchsale = await _saleRepository.GetSaleByIdAsync(id);
            if (Searchsale == null)
                throw new Exception("Venta no encontrada");

            var product = await _productRepository.GetByIdAsync(Searchsale.ProductId);
            if (product == null)
                throw new Exception("Producto no encontrado");

            product.ProductDetail.Stock = product.ProductDetail.Stock + Searchsale.Quantity;

            await _productRepository.UpdateProductStockAsync(product);

            await _saleRepository.DeleteSaleAsync(id);
        }

        public Task GetSalesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
