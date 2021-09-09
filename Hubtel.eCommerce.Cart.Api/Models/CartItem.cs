using System;
using System.ComponentModel.DataAnnotations;

namespace Hubtel.eCommerce.Cart.Api.Model
{
    public class CartItem
    {
        public CartItem()
        {
            Product = new Product();
        }
        [Key]
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        [Range(1, 99)]
        public int Quantity { get; set; }
        [Phone]
        [StringLength(10, ErrorMessage = "Phone Length should be 10 in format (0234567891)")]
        [MinLength(10, ErrorMessage = "Phone Length should be 10 in format (0234567891)")]
        [RegularExpression(@"\^?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", ErrorMessage = "Phone Number should follow 0234567891 format")]
        public string PhoneNumber { get; set; }
        public DateTime TimeAdded { get; set; }
    }
}
