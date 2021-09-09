using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hubtel.eCommerce.Cart.Api.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Phone][Required]
        [StringLength(10, ErrorMessage = "Phone Length should be 10 in format (0234567891)")]
        [MinLength(10, ErrorMessage = "Phone Length should be 10 in format (0234567891)")]
        [RegularExpression(@"\^?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", ErrorMessage = "Phone Number should follow 0234567891 format")]

        public string PhoneNumber { get; set; }
    }
}
