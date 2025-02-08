namespace Latiendita.Dtos.Product
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public int Stock { get; set; }
    }
}