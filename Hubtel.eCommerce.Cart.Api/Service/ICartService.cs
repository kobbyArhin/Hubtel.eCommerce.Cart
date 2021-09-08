using Hubtel.eCommerce.Cart.Api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hubtel.eCommerce.Cart.Api.Service
{
    public interface ICartService
    {
        Task<CartItem> AddItemintoCartAsync(CartItem cartItem);
        Task<IList<CartItem>> ChangeCartItemQuantityAsync(int id, int quantity);
        Task<IList<CartItem>> ClearCartAsync(string phoneNumber);
        Task<IList<CartItem>> DeleteCartItemByIdAsync(int id);
        Task<IList<CartItem>> GetCartItemsAsync(string phoneNumber);
    }
}