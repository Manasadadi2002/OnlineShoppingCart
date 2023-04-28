using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Models
{
    public class Payment
    {
        [Key]
        public int TransactionId { get; set; }
        public decimal TransactionAmount { get; set; }

        [ForeignKey("UserTable")]
        public int UserId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public string Tstatus { get; set; }
        public string Mode { get; set; }
        public string Code { get; set; }
    }
}
