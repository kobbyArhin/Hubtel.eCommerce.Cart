using Hubtel.eCommerce.Cart.Api.Models;
using Hubtel.eCommerce.Cart.Api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hubtel.eCommerce.Cart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : Controller
    {
        private readonly ICartService _context;

        public CartItemsController(ICartService context)
        {
            _context = context;
        }

        // POST api/CartItems
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CartItem cartItem)
        {
            await _context.AddItemintoCartAsync(cartItem);
            return Created($"CartItems", cartItem);
        }

        // GET: api/CartItems/GetCartItems
        [HttpGet("GetCartItems/{phoneNumber}")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems(string phoneNumber)
        {
            IList<CartItem> cartItems = await _context.GetCartItemsAsync(phoneNumber);
            return Ok(cartItems);
        }

        // PUT api/CartItems/ChangeItemQuantity/5/4
        [HttpPut("ChangeItemQuantity/{cartItemId}/{quantity}")]
        public async Task<IActionResult> ChangeItemQuantity(int cartItemId, int quantity)
        {
            IList<CartItem> cartItems = await _context.ChangeCartItemQuantityAsync(cartItemId, quantity);
            if (cartItems == null)
                return NotFound("Item not found in the cart, please check the cartItemId");
            return Ok(cartItems);
        }

        // DELETE: api/CartItems/ClearCart/1
        [HttpDelete("ClearCart/{phoneNumber}")]
        public async Task<IActionResult> ClearCart(string phoneNumber)
        {
            IList<CartItem> cartItems = await _context.ClearCartAsync(phoneNumber);
            return Ok(cartItems);
        }

        // DELETE api/CartItems/DeleteItemFromCart/5
        [HttpDelete("DeleteItemFromCart/{cartItemId}")]
        public async Task<IActionResult> DeleteItemFromCart(int cartItemId)
        {
            IList<CartItem> cartItems = await _context.DeleteCartItemByIdAsync(cartItemId);
            if (cartItems == null)
                return NotFound("Item not found in the cart, please check the cartItemId");
            return Ok(cartItems);
        }
    }
}
