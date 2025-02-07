namespace Latiendita.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
    }
}