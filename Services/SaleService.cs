using Latiendita.Repositories;
using Latiendita.Models;   
using Latiendita.Dtos;

namespace Latiendita.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
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
            var sale = new Sale
            {
                Quantity = saleDto.Quantity,
                ProductId = saleDto.ProductId,
                Product = saleDto.Product != null ? new Product
                {
                    Name = saleDto.Product.Name,
                    Price = saleDto.Product.Price,
                    CategoryId = saleDto.Product.CategoryId,
                    Category = saleDto.Product.Category
                } : null
            };

            await _saleRepository.AddSaleAsync(sale);
        } 

        public async Task UpdateSaleAsync(int id, SaleDto saleDto)
        {
            var sale = new Sale
            {
                Quantity = saleDto.Quantity,
                ProductId = saleDto.ProductId,
                Product = saleDto.Product != null ? new Product
                {
                    Name = saleDto.Product.Name,
                    Price = saleDto.Product.Price,
                    CategoryId = saleDto.Product.CategoryId,
                    Category = saleDto.Product.Category
                } : null
            };

            await _saleRepository.UpdateSaleAsync(id, sale);
        }     

        public async Task DeleteSaleAsync(int id)
        {
            await _saleRepository.DeleteSaleAsync(id);
        }
    }
}