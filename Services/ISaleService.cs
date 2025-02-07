using Latiendita.Models;
using Latiendita.Dtos;

namespace Latiendita.Services
{
    public interface ISaleService
    {
        Task<IEnumerable<Sale>> GetAllSalesAsync();
        Task<Sale?> GetSaleByIdAsync(int id);
        Task CreateSaleAsync(SaleDto saleDto);
        Task UpdateSaleAsync(int id, SaleDto saleDto);
        Task DeleteSaleAsync(int id);
    }

}