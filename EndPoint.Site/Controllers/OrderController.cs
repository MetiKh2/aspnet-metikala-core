using MetiKala.Application.Interfaces;
using MetiKala.Domain.Entities.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IProductsService _productsService;
        public OrderController(IOrderService orderService, IUserService userService, IProductsService productsService)
        {
            _productsService = productsService;
            _userService = userService;
            _orderService = orderService;
        }
        [Route("Cart")]
        [Authorize]
        public IActionResult Cart(string ResultDiscount="")
        {
            ViewBag.ResultDiscount = ResultDiscount;
            return View(_orderService.GetCurrentCart(User.Identity.Name));
        }

        public IActionResult AddOrder(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Login");
            }
            var product = _productsService.GetProductByID(id);
            if (product==null)
            {
                return NotFound(); 
            }

            _orderService.AddOrder(User.Identity.Name,id);
            return Redirect("/Cart");
        }

        public IActionResult MinusFromOrder(int id)
        {
            _orderService.MinusOrderDetail(User.Identity.Name,id);
            return Redirect("/Cart");
        }
        [Authorize]
        [Route("RequestPayment/{orderId}")]
        public IActionResult RequestPayment(int orderId)
        {
          var order=  _orderService.GetOrderByID(User.Identity.Name,orderId);
            if (order==null)
            {
                return NotFound();
            }
            var payment = new ZarinpalSandbox.Payment(order.SumAmount);
            var res = payment.PaymentRequest("نهایی کرئن خرید", "https://localhost:44397/OnlinePayment/" + order.OrderID);
            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }
            return null;
        }
        [Authorize]
        [Route("OnlinePayment/{id}")]
        public IActionResult FinallyOnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                   HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                   && HttpContext.Request.Query["Authority"] != "")
            {

                var order = _orderService.GetOrderByID(User.Identity.Name, id);
                if (order == null)
                {
                    return NotFound();
                }

                string authority = HttpContext.Request.Query["Authority"];

                var payment = new ZarinpalSandbox.Payment(order.SumAmount);

                var res = payment.Verification(authority).Result;

                if (res.Status == 100)
                {
                    ViewBag.code = res.RefId;
                    ViewBag.IsSuccess = true;
                    order.IsFinally = true;
                    order.OrderState = OrderState.Processing;
                    _orderService.UpdateOrder(order);
                }



            }
                return View();
        }

        [Authorize]
        [Route("/ShowOrders")]
        public IActionResult ShowOrders()
        {

            return View(_orderService.GetOrderByUserName(User.Identity.Name));
        }

        [Authorize]
        [Route("/OrderDetails/{orderId}")]
        public IActionResult OrderDetails(int orderId)
        {

            return View(_orderService.GetOrderByID(User.Identity.Name,orderId));
        }

        [Authorize]
       // [Route("UseDiscountCode/{orderId}")]
        public IActionResult UseDiscountCode(int orderId,string code)
        {
          var result= _productsService.UseDiscount(code,User.Identity.Name,orderId);
            return Redirect("/Cart?ResultDiscount="+result);
        }
    }
}
