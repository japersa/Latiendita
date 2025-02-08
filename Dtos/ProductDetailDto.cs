using Latiendita.Models;
using System.Diagnostics.CodeAnalysis;

namespace AppProducts.Dtos
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } 
        public required string Description { get; set; }
        public required string Image { get; set; }
    }
}