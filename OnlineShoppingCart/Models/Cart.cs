using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
       [ForeignKey("UserTable")]
        public int UserId { get; set; }
        [ForeignKey("Product")]

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }

    }
}
