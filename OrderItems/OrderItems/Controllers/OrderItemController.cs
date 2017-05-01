using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderItems.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace OrderItems.Controllers
{
    public class OrderItemController : Controller
    {
        private OrderItemsContext contextDB = new OrderItemsContext();

        // GET: OrderItem
        public ActionResult Index()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            var orderIds = (from o in contextDB.OrderItems select o.OrderItemId);
            foreach(int id in orderIds)
            {
                listItems.Add(new SelectListItem
                {
                    Text = id.ToString(),
                    Value = id.ToString()
                });
            }
            ViewBag.OrderId = listItems;
            var orderItem = contextDB.OrderItems.Find(1);
            Debug.WriteLine(orderItem.Order.Buyer);

            return View("Index", orderItem);
        }

        //GET: OrderItem/Edit
        public ActionResult Edit()
        {
            Debug.WriteLine("Edit: GET");
            var orderItem = contextDB.OrderItems.Find(1);
            return View(orderItem);
        }

        //POST: OrderItem/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderItem orderItem)
        {
            try
            {
                Debug.WriteLine("Edit: POST");
                contextDB.Entry(orderItem).State = EntityState.Modified;
                contextDB.Entry(orderItem.Order).State = EntityState.Modified;
                foreach (var i in orderItem.Items)
                {
                    contextDB.Entry(i).State = EntityState.Modified;
                }
                contextDB.SaveChanges();
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
                return View(orderItem);
            }
            return View(orderItem);
        }

        //GET: OrderItem/ListPartial
        public PartialViewResult ListPartial(int i)
        {
            if(i != 0)
            {
                OrderItem orderItem = contextDB.OrderItems.Find(i);
                return PartialView(@"~/Views/OrderItem/_Edit.cshtml", orderItem);
            }
            return PartialView(@"~/Views/OrderItem/_Edit.cshtml", new OrderItem());
        }

        //POST: OrderItem/ListPartial
        [HttpPost]
        public ActionResult ListPartial(List<Item> items)
        {
            try
            {
                items.ForEach(i => contextDB.Entry(i).State = EntityState.Modified);
                contextDB.SaveChanges();
                Debug.WriteLine("Partail view POST");
            }
            catch
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit");
        }
    }
}