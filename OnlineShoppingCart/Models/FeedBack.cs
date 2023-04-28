using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Models
{
    public class FeedBack
    {
        [Key]
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public string feedback { get; set; }
    }
}
