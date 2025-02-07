using Latiendita.Models;

namespace Latiendita.Dtos
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; } 
        public required string Description { get; set; }
        public required string Image { get; set; }
        public decimal Stock { get; set; }
        public decimal Weight { get; set; }
        public decimal Dimensions { get; set; }
    }
}