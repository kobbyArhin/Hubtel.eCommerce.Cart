using Hubtel.eCommerce.Cart.Api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hubtel.eCommerce.Cart.Api.Service
{
    public interface IProductService
    {
        Task<IList<Product>> GetProductsAsync();        
        Task<Product> GetProductAsync(int productId);
    }
}
