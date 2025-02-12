using Latiendita.Models;
using Microsoft.EntityFrameworkCore;

namespace Latiendita.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductDetail> ProducDetails { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
            .HasOne(p => p.ProductDetail)
            .WithOne(pd => pd.Product)
            .HasForeignKey<ProductDetail>(pd => pd.Id);

            modelBuilder.Entity<Sale>()
           .HasMany(s => s.SaleDetails)
           .WithOne(sd => sd.Sale)
           .HasForeignKey(sd => sd.SaleId);

            modelBuilder.Entity<Product>()
           .HasMany(p => p.SaleDetails)
           .WithOne(sd => sd.Product)
           .HasForeignKey(sd => sd.ProductId);
        }
    }
}