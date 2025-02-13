using System.ComponentModel.DataAnnotations.Schema;

namespace Latiendita.Models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
        public required ProductDetail ProductDetail { get; set; }
    }
}