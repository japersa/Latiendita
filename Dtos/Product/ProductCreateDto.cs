namespace Latiendita.Dtos.Product
{
	public class ProductCreateDto
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int CategoryId { get; set; }
		public string? Description { get; set; }
		public int Stock { get; set; }
		public decimal? Weight { get; set; }
		public string? Dimensions { get; set; }
	}
}