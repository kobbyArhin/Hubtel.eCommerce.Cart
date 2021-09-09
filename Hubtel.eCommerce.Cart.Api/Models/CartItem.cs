using Hubtel.eCommerce.Cart.Api.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hubtel.eCommerce.Cart.Api.Model
{
    public class CartItem
    {
        public CartItem()
        {
            Customer = new Customer();
            Product = new Product();
        }
        [Key]
        public int CartItemId { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        [Range(1, 99)]
        public int Quantity { get; set; }
        public DateTime TimeAdded { get; set; }
    }
}
