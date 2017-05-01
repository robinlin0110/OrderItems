using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OrderItems.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        
        public string Buyer { get; set; }

        public Order() { }
    }
}