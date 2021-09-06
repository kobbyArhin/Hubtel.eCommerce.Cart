﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hubtel.eCommerce.Cart.Api.Models;
using System;

namespace Hubtel.eCommerce.Cart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ShoppingCartContext _context;

        public CartItemsController(ShoppingCartContext context)
        {
            _context = context;
        }

        // GET: api/CartItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
        {
            return await _context.CartItems.ToListAsync();
        }

        // GET: api/CartItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> GetCartItem(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);

            if (cartItem == null)
            {
                return NotFound();
            }

            return cartItem;
        }

        // PUT: api/CartItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartItem(int id, CartItem cartItem)
        {
            if (id != cartItem.ItemID)
            {
                return BadRequest();
            }

            _context.Entry(cartItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CartItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CartItem>> PostCartItem(CartItem cartItem)
        {
            try
            {
                _context.CartItems.Add(cartItem);
                await _context.SaveChangesAsync();
            }
            catch(ArgumentException)
            {
                _context.Entry(cartItem).State = EntityState.Modified;
                await _context.SaveChangesAsync();  
            }

            return CreatedAtAction(nameof(GetCartItem), new { id = cartItem.ItemID }, cartItem);
        }

        // DELETE: api/CartItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartItem>> DeleteCartItem(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            return cartItem;
        }

        private bool CartItemExists(int id)
        {
            return _context.CartItems.Any(e => e.ItemID == id);
        }
    }
}
