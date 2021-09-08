using Hubtel.eCommerce.Cart.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hubtel.eCommerce.Cart.Api.Service
{
    public interface ICartService
    {
        Task<CartItem> AddItemintoCartAsync(CartItem cartItem);
        Task<IList<CartItem>> GetCartItemsAsync(string phoneNumber);
        Task<IList<CartItem>> ChangeCartItemQuantityAsync(int id, int quantity);
        Task<IList<CartItem>> ClearCartAsync(string phoneNumber);
        Task<IList<CartItem>> DeleteCartItemByIdAsync(int id);
        
    }
}
