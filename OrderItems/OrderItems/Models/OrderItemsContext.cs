using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OrderItems.Models
{
    public class OrderItemsContext: DbContext
    {
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}