using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hubtel.eCommerce.Cart.Api.Models;
using Hubtel.eCommerce.Cart.Api.Models.EntityFrameWork;
using Hubtel.eCommerce.Cart.Api.Service;

namespace Hubtel.eCommerce.Cart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _context;

        public ProductsController(IProductService context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _context.GetProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(int productId)
        {
            try
            {
                var product = await _context.GetProductAsync(productId);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
