namespace Latiendita.Models
{
    public class SaleDetail
    {
        public int Id { get; set; }
        public int SaleId { get; set; } // Clave foránea a Sale
        public Sale Sale { get; set; } = null!;

        public int ProductId { get; set; } // Clave foránea a Product
        public required Product Product { get; set; } = null!;

        public int Quantity { get; set; }  // Cantidad vendida
        public decimal Price { get; set; }
    }
}
