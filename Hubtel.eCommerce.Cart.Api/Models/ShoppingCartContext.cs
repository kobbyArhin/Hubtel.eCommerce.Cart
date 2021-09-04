using Microsoft.EntityFrameworkCore;

namespace Hubtel.eCommerce.Cart.Api.Models
{
    public class ShoppingCartContext:DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
            : base(options)
        {
        }

        public DbSet<CartItem> CartItems { get; set; }
    }
}
