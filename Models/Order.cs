using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Latiendita.Models
{
    public class Order () 
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public required Product Product { get; set; } = null!;
        public int Quantity { get; set; }
    }
}