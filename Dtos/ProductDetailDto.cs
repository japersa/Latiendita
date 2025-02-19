using Latiendita.Models;

namespace Latiendita.Dtos
{
    public class ProductDetailDto  // Cambio de nombre para evitar conflictos
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal Weight { get; set; }
        public string Dimensions { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public required Category Category { get; set; }

        public decimal Price { get; set; }

    }
}
