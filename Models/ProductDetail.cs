namespace Latiendita.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public decimal Stock { get; set; }
        public decimal Weight { get; set; }
        public decimal Dimensions { get; set; }
    }
}