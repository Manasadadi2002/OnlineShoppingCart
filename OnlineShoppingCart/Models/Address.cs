using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Models
{
    public class Address
    {
        [Key]
        public int AddId { get; set; }
        [ForeignKey("UserTable")]
        public int UserId { get; set; }
        public string AddressInfo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
    }
}
