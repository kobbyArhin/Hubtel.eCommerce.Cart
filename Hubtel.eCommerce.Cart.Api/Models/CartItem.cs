using System.ComponentModel.DataAnnotations;

namespace Hubtel.eCommerce.Cart.Api.Models
{
    public class CartItem
    {
        [Key]
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
