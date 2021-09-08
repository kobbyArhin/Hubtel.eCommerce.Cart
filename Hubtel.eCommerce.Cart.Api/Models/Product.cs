using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hubtel.eCommerce.Cart.Api.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        //[Required(AllowEmptyStrings = false)]
        public string ProductName { get; set; }
        //[Required(AllowEmptyStrings=false)]
        [Range(0, 9999.99)]
        public decimal UnitPrice { get; set; }
    }
}
