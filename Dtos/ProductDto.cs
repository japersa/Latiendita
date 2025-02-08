using Latiendita.Dtos;
using Latiendita.Models;

namespace Latiendita.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public ProductDetailDto? ProductDetail { get; set; } 
    }
}