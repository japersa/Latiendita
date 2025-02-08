namespace Latiendita.Models
{
    public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    
    public int CategoryId { get; set; }
    public required Category Category { get; set; }
    
    // Campos de ProductDetails
    public string? Description { get; set; }
    public int Stock { get; set; }
    public decimal? Weight { get; set; }
    public string? Dimensions { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
}