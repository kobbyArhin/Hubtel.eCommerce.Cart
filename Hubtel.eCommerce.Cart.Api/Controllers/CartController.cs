using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hubtel.eCommerce.Cart.Api.Service;
using Hubtel.eCommerce.Cart.Api.Model;

namespace Hubtel.eCommerce.Cart.Api.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly ICartService _iCartService;
        public CartController(ICartService iCartService)
        {
            _iCartService = iCartService;
        }

        // POST api/Cart
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CartItem cartItem)
        {
            await _iCartService.AddItemintoCartAsync(cartItem);
            return Created($"Cart", cartItem);
        }

        // PUT api/Cart/ChangeItemQuantity/5/4
        [HttpPut("ChangeItemQuantity/{cartItemId}/{quantity}")]
        public async Task<IActionResult> ChangeItemQuantity(int cartItemId, int quantity)
        {
            IList<CartItem> cartItems = await _iCartService.ChangeCartItemQuantityAsync(cartItemId, quantity);
            if (cartItems == null)
                return NotFound("Item not found in Cart");
            return Ok(cartItems);
        }

        // DELETE api/Cart/RemoveItemFromCart/5
        [HttpDelete("RemoveItemFromCart/{cartItemId}")]
        public async Task<IActionResult> RemoveItemFromCart(int cartItemId)
        {
            IList<CartItem> cartItems = await _iCartService.RemoveCartItemByIdAsync(cartItemId);
            if (cartItems == null)
                return NotFound("Item not found in Cart");
            return Ok(cartItems);
        }

        // GET: api/Cart/GetCartItems
        [HttpGet("GetCartItemsByPhoneNumber/{phoneNumber}")]
        public async Task<IActionResult> GetCartItems(string phoneNumber)
        {
            IList<CartItem> cartItems = await _iCartService.GetCartItemsAsync(phoneNumber);
            return Ok(cartItems);
        }

        // GET: api/Cart/GetCartItems
        [HttpGet("GetCartItemsByQuantity/{quantity}")]
        public async Task<IActionResult> GetCartItems(int quantity)
        {
            IList<CartItem> cartItems = await _iCartService.GetCartItemsAsync(quantity);
            return Ok(cartItems);
        }
    }
}
