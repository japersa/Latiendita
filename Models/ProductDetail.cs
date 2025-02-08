namespace Latiendita.Models
{
    public class ProductDetail
    {
        public int Id { get; set; } // Si usas Entity Framework
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal Weight { get; set; }
        public string Dimensions { get; set; } = string.Empty;
        public int CategoryId { get; set; } // Relación con Categoría
        public Category Category { get; set; } = null!; // Relación con Categoría
    }
}
