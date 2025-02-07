using Latiendita.Models;

namespace Latiendita.Repositories
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetSalesAsync();
        Task<Sale> GetSaleByIdAsync(int id);
        Task AddSaleAsync(Sale sale);
        Task UpdateSaleAsync(int id, Sale sale);
        Task DeleteSaleAsync(int id);
    }
}
