using System.ComponentModel.DataAnnotations;

namespace Hubtel.eCommerce.Cart.Api.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public double UnitPrice { get; set; }
    }
}
