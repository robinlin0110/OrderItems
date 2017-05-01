using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OrderItems.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }
    }

}