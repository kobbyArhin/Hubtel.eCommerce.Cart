using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hubtel.eCommerce.Cart.Api.Service;

namespace Hubtel.eCommerce.Cart.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private readonly IProductService _iProductService;

        public ProductController(IProductService iProductService)
        {
            _iProductService = iProductService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _iProductService.GetProductsAsync();
                return Ok(products);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(int productId)
        {
            try
            {
                var product = await _iProductService.GetProductAsync(productId);

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
