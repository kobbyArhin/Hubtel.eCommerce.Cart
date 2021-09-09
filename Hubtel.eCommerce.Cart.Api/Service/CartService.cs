using Hubtel.eCommerce.Cart.Api.Model;
using Hubtel.eCommerce.Cart.Api.Model.GenericRepository.Repository;
using Hubtel.eCommerce.Cart.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hubtel.eCommerce.Cart.Api.Service
{
    public class CartService : ICartService
    {
        private readonly IRepository _iRepository;
        public CartService(IRepository iRepository)
        {
            _iRepository = iRepository;
        }

        public async Task<CartItem> AddItemintoCartAsync(CartItem cartItem)
        {
            IEnumerable<CartItem> cartItems = await _iRepository.GetAsync<CartItem>(c => c.Customer.PhoneNumber == cartItem.Customer.PhoneNumber);
            try
            {
                IEnumerable<CartItem> existingItem = await _iRepository.GetAsync<CartItem>(c=>c.Product.ProductId==cartItem.Product.ProductId);
                cartItem.Quantity += existingItem.Last().Quantity;
                cartItem.CartItemId = existingItem.Last().CartItemId;
                _iRepository.Update<CartItem>(cartItem);
                await _iRepository.SaveAsync();
                return cartItem;
            }
            catch (InvalidOperationException)
            {
                if (cartItems.Any())
                {
                    cartItem.CartItemId = cartItems.Last().CartItemId + 1;
                }
                else
                {
                    cartItem.CartItemId = 1;
                }

                _iRepository.Create<CartItem>(cartItem);
                await _iRepository.SaveAsync();
                return cartItem;
            }
        }

        public async Task<IList<CartItem>> GetCartItemsAsync(string phoneNumber)
        {
            var cartItems = await _iRepository.GetAsync<CartItem>(c => c.Customer.PhoneNumber == phoneNumber);
            cartItems = PopulateProductIntoCartItem(cartItems.ToList());
            return cartItems.ToList();
        }

        public async Task<IList<CartItem>> GetCartItemsAsync(int quantity)
        {
            var cartItems = await _iRepository.GetAsync<CartItem>(c => c.Quantity == quantity);
            cartItems = PopulateProductIntoCartItem(cartItems.ToList());
            return cartItems.ToList();
        }

        public async Task<IList<CartItem>> RemoveCartItemByIdAsync(int id)
        {
            var cartItem = await _iRepository.GetByIdAsync<CartItem>(id);
            if (cartItem != null)
            {
                _iRepository.Delete<CartItem>(cartItem);
                await _iRepository.SaveAsync();
            }

            return await GetCartItemsAsync(cartItem.Customer.PhoneNumber);
        }

        public async Task<IList<CartItem>> ChangeCartItemQuantityAsync(int id, int quantity)
        {
            var cartItem = await _iRepository.GetByIdAsync<CartItem>(id);

            if (cartItem == null)
                return null;

            cartItem.Quantity = quantity;

            _iRepository.Update<CartItem>(cartItem);
            await _iRepository.SaveAsync();
            return await GetCartItemsAsync(cartItem.Customer.PhoneNumber);
        }

        #region Private Helper
        /// <summary>
        /// this method will be absolute when we have the actuall database, in memory database does not supoort relation database
        /// </summary>
        private List<CartItem> PopulateProductIntoCartItem(List<CartItem> cartItems)
        {
            foreach (var cartItem in cartItems)
            {
                cartItem.Product = _iRepository.GetById<Product>(cartItem.ProductId);
                cartItem.Customer = _iRepository.GetById<Customer>(cartItem.CustomerId);
            }

            return cartItems;
        }

        #endregion
    }
}
