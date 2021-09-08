using Hubtel.eCommerce.Cart.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hubtel.eCommerce.Cart.Api.Service
{
    public interface IProductService
    {
        Task<IList<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int productId);
    }
}
