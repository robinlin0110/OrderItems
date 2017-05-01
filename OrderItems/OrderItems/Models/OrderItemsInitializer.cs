using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Diagnostics;

namespace OrderItems.Models
{
    public class OrderItemsInitializer: DropCreateDatabaseAlways<OrderItemsContext>
    {
        // Puts sample data into the database
        protected override void Seed(OrderItemsContext context)
        {
            var items = new List<Item>
            {
                new Item
                {
                    ItemId = 1,
                    Name = "Chair",
                    Price = 100
                },
                new Item
                {
                    ItemId = 2,
                    Name = "Desk",
                    Price = 200
                },
                new Item
                {
                    ItemId = 3,
                    Name = "Book",
                    Price = 300
                },
                new Item
                {
                    ItemId = 4,
                    Name = "Pen",
                    Price = 30
                }
            };
            items.ForEach(i => context.Items.Add(i));
            //context.SaveChanges();

            var orders = new List<Order>
            {
                new Order
                {
                    OrderId = 1,
                    Buyer = "Alan"
                },
                new Order
                {
                    OrderId = 2,
                    Buyer = "Bob"
                }
            };            
            orders.ForEach(i => context.Orders.Add(i));
            context.SaveChanges();

            var orderItems = new List<OrderItem>
            {
                new OrderItem()
                {
                    OrderItemId = 1,
                    Order = context.Orders.Find(1),
                    Items = (from p in context.Items where p.ItemId < 4 select p).ToList()
                },
                new OrderItem()
                {
                    OrderItemId = 2,
                    Order = context.Orders.Find(2),
                    Items = (from p in context.Items where p.ItemId > 1 select p).ToList()
                }
            };
            orderItems.ForEach(i => context.OrderItems.Add(i));
            context.SaveChanges();
        }
    }
}