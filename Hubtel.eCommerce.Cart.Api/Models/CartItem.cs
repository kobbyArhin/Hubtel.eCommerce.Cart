using System.ComponentModel.DataAnnotations;

namespace Hubtel.eCommerce.Cart.Api.Models
{
    public class CartItem
    {
        [Key]
        public int ItemID { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Range(0, 9999.99)]
        public double UnitPrice { get; set; }
    }
}
