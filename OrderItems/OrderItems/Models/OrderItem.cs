using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OrderItems.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public virtual Order Order { get; set; }

        public virtual List<Item> Items { get; set; }

        public OrderItem(): base() { }
        
    }
}