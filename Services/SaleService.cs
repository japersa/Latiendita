using Latiendita.Repositories;
using Latiendita.Models;
using Latiendita.Dtos;

namespace Latiendita.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository; // Agregado

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
            var product = await _productRepository.GetByIdAsync(saleDto.ProductId); // Usar saleDto.ProductId
            if (product == null) throw new Exception("Producto no encontrado");

            var sale = new Sale
            {
                Product = product, // Asignar directamente el producto
                Quantity = saleDto.Quantity
            };

            await _saleRepository.AddSaleAsync(sale);
        }

        public async Task UpdateSaleAsync(int id, SaleDto saleDto)
        {
            var product = await _productRepository.GetByIdAsync(saleDto.ProductId);
            if (product == null) throw new Exception("Producto no encontrado");

            var sale = new Sale
            {
                Id = id,
                Product = product, // Asignar directamente el producto
                Quantity = saleDto.Quantity
            };

            await _saleRepository.UpdateSaleAsync(id, sale);
        }

        public async Task DeleteSaleAsync(int id)
        {
            await _saleRepository.DeleteSaleAsync(id);
        }
    }
}
