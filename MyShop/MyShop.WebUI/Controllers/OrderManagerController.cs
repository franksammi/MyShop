﻿using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Services;
using MyShop.Core.Contracts;

namespace MyShop.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderManagerController : Controller
    {
        IOrderService orderService;

        public OrderManagerController(IOrderService OrderService)
        {
            this.orderService = OrderService;
        }
        // GET: OrderManager
        public ActionResult Index()
        {
            List<Order> orders = orderService.GetOrderList();
            return View(orders);
        }

        public ActionResult UpdateOrder(string Id)
        {
            ViewBag.StatusList = new List <string>() {
                "Order Created",
                "Payment Processed",
                "Order Shipped",
                "Order Complete"
            };
            Order order = orderService.GetOrder(Id);

            return View(order);
        }
        [HttpPost]
        public ActionResult UpdateOrder(Order UpdatedOrder, string Id)
        {
            Order order = orderService.GetOrder(Id);
            order.OrderStatus=UpdatedOrder.OrderStatus;
          //  order.City = UpdatedOrder.City;
            orderService.UpdateOrder(order);
            return RedirectToAction("Index");
        }

      
    }
}