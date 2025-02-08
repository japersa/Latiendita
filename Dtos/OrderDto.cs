using Latiendita.Models;

namespace Latiendita.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public required Product Product { get; set; }
        public int Quantity { get; set; }


    }
}