using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstServices.Interfaces;
using EasyCombos.CodeFirstEntities;
using EasyCombos.DAL;
using EasyCombos.UI.Models;

namespace EasyCombos.UI.Controllers
{ 
    public class OrderController : Controller
    {
       private readonly IOrderService _OrderService;
       private OrderModel _orderModel = new OrderModel();


        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }


        public ViewResult Index()
        {
            var orderList = _OrderService.GetOrder().ToList();
            return View(_orderModel.GetModel(orderList));
        }


        public ViewResult Details(int id)
        {
            Order Order = _OrderService.GetOrderById(id);
            return View(_orderModel.GetModel(Order));
        }

        public ActionResult Create()
        {
            return View();
        } 


        [HttpPost]
        public ActionResult Create(Order Order)
        {
            if (ModelState.IsValid)
            {
                _OrderService.CreateOrder(Order);
                return RedirectToAction("Index");  
            }

            return View(_orderModel.GetModel(Order));
        }
        
 
        public ActionResult Edit(int id)
        {
            Order Order = _OrderService.GetOrderById(id);
            return View(_orderModel.GetModel(Order));
        }


        [HttpPost]
        public ActionResult Edit(Order Order)
        {
            if (ModelState.IsValid)
            {
                _OrderService.UpdateOrder(Order);
                return RedirectToAction("Index");
            }
            return View(_orderModel.GetModel(Order));
        }

 
        public ActionResult Delete(int id)
        {
            Order Order = _OrderService.GetOrderById(id);
            return View(_orderModel.GetModel(Order));
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            _OrderService.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}