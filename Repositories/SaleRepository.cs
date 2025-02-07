using Latiendita.Data;
using Latiendita.Models;
using Microsoft.EntityFrameworkCore;

namespace Latiendita.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _context;

        public SaleRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Sale>> GetSalesAsync()
        {
            return await _context.Sales.Include(s => s.Product).ToListAsync();
        }

        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            var sale = await _context.Sales.Include(s => s.Product).FirstOrDefaultAsync(s => s.Id == id);
            if (sale == null)
            {
                throw new KeyNotFoundException($"Sale with ID {id} not found");
            }
            return sale;
        }

        public async Task AddSaleAsync(Sale sale)
        {
            if (sale == null)
            {
                throw new ArgumentNullException(nameof(sale));
            }
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSaleAsync(int id, Sale sale)
        {
            if (sale == null)
            {
                throw new ArgumentNullException(nameof(sale));
            }

            if (id != sale.Id)
            {
                throw new ArgumentException("Sale ID mismatch");
            }

            var existingSale = await GetSaleByIdAsync(id);
            _context.Entry(existingSale).CurrentValues.SetValues(sale);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSaleAsync(int id)
        {
            var sale = await GetSaleByIdAsync(id);
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
        }
    }
}
