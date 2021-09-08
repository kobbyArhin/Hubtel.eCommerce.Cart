using Hubtel.eCommerce.Cart.Api.Models;
using Hubtel.eCommerce.Cart.Api.Models.GenericRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hubtel.eCommerce.Cart.Api.Service
{
    public class CartServices : ICartService
    {
        private readonly IRepository _iRepository;
        public CartServices(IRepository iRepository)
        {
            _iRepository = iRepository;
        }

        public async Task<CartItem> AddItemintoCartAsync(CartItem cartItem)
        {
            IEnumerable<CartItem> cartItems = await _iRepository.GetAsync<CartItem>(c => c.PhoneNumber == cartItem.PhoneNumber);
            
            if (cartItems.Count() > 0)
            {
                cartItem.ItemID = cartItems.Last().ItemID + 1;
            }
            else
            {
                cartItem.ItemID = 1;
            }

            _iRepository.Create<CartItem>(cartItem);
            await _iRepository.SaveAsync();
            return cartItem;
        }

        public async Task<IList<CartItem>> GetCartItemsAsync(string phoneNumber)
        {
            var cartItems = await _iRepository.GetAsync<CartItem>(c => c.PhoneNumber == phoneNumber);
            cartItems = PopulateProductIntoCartItem(cartItems.ToList());
            return cartItems.ToList();
        }

        public async Task<IList<CartItem>> ChangeCartItemQuantityAsync(int id, int quantity)
        {
            var cartItem = await _iRepository.GetByIdAsync<CartItem>(id);

            if (cartItem == null)
                return null;

            cartItem.Quantity = quantity;

            _iRepository.Update<CartItem>(cartItem);
            await _iRepository.SaveAsync();
            return await GetCartItemsAsync(cartItem.PhoneNumber);
        }

        public async Task<IList<CartItem>> ClearCartAsync(string phoneNumber)
        {
            var cartItems = await _iRepository.GetAsync<CartItem>(b => b.PhoneNumber == phoneNumber);

            foreach (var cartItem in cartItems)
            {
                _iRepository.Delete<CartItem>(cartItem);
            }
            await _iRepository.SaveAsync();

            return await GetCartItemsAsync(phoneNumber);
        }

        public async Task<IList<CartItem>> DeleteCartItemByIdAsync(int id)
        {
            var cartItem = await _iRepository.GetByIdAsync<CartItem>(id);
            if (cartItem != null)
            {
                _iRepository.Delete<CartItem>(cartItem);
                await _iRepository.SaveAsync();
            }

            return await GetCartItemsAsync(cartItem.PhoneNumber);
        }

        #region Private Helper
        /// <summary>
        /// this method will be absolute when we have the actuall database, in memory database does not supoort relation database
        /// </summary>
        private List<CartItem> PopulateProductIntoCartItem(List<CartItem> cartItems)
        {
            foreach (var cartItem in cartItems)
            {
                cartItem.Product = _iRepository.GetById<Product>(cartItem.ProductID);
            }

            return cartItems;
        }

        #endregion
    }
}
