namespace Latiendita.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ProductDetail? ProductDetail { get; set; }

        public List<SaleDetail> SaleDetails { get; set; } = new();
    }
}
