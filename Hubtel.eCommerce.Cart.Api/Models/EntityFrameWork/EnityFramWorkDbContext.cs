using Hubtel.eCommerce.Cart.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hubtel.eCommerce.Cart.Api.Model.EntityFrameWork
{
    public partial class EnityFramWorkDbContext : DbContext
    {
        public EnityFramWorkDbContext(DbContextOptions<EnityFramWorkDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
    }
}
