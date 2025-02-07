namespace Latiendita.Dtos.Product
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public decimal? Weight { get; set; }
        public string? Dimensions { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}