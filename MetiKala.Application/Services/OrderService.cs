using MetiKala.Application.Interfaces;
using MetiKala.Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDatabaseContext _context;
        private readonly IUserService _userService;
        private readonly IProductsService _productsService;
        public OrderService(IDatabaseContext context,IUserService userService,IProductsService productsService)
        {
            _context = context;
            _productsService = productsService;
            _userService = userService;
           
        }
        public int AddOrder(string username, int productId)
        {
            var userId = _userService.GetUserIDByUserName(username);
            var order = _context.Orders.FirstOrDefault(p => p.IsFinally==false&&p.UserID==userId);
            var product = _productsService.GetProductByID(productId);
            if (order == null)
            {
                Order newOrder = new Order
                {
                    SumAmount = product.Price,
                    UserID = userId,
                    OrderDetails = new List<OrderDetail> { new OrderDetail { Count = 1, Price = product.Price, ProductID = productId } },
                };
                _context.Orders.Add(newOrder);
                _context.SaveChanges();
                return newOrder.OrderID;
            }
            else
            {
                OrderDetail detail = _context.OrderDetails.Where(p => p.OrderID == order.OrderID && p.ProductID == productId).FirstOrDefault();
                if (detail==null)
                {
                    detail = new OrderDetail { 
                    Count=1,Price=product.Price,
                     OrderID=order.OrderID,
                     ProductID=productId
                    };
                    _context.OrderDetails.Add(detail);
                
                }
                else
                {
                    detail.Count++;
                    _context.OrderDetails.Update(detail);
                }
                _context.SaveChanges();
                UpdateOrderSumAmount(order.OrderID);
                return order.OrderID;
            }
          
        }

        public Order GetCurrentCart(string username)
        {
            var userId = _userService.GetUserIDByUserName(username);
            return _context.Orders.Include(p => p.OrderDetails).ThenInclude(p => p.Product).Where(p => p.IsFinally == false&&p.UserID==userId).FirstOrDefault();
        }

        public Order GetOrderByID(string username,int id)
        {
            var userId = _userService.GetUserIDByUserName(username);
            return _context.Orders.Include(p=>p.OrderDetails).ThenInclude(p=>p.Product).FirstOrDefault(p=>p.OrderID==id&&p.UserID==userId);
        }

        public List<Order> GetOrderByUserName(string username)
        {
            return _context.Orders.Where(p => p.UserID == _userService.GetUserIDByUserName(username)).ToList();
        }

        public void MinusOrderDetail(string username, int productId)
        {
            var userId = _userService.GetUserIDByUserName(username);
            var order = _context.Orders.Where(p => p.UserID == userId && p.IsFinally == false).FirstOrDefault();
            var orderDetail = _context.OrderDetails.Where(p => p.OrderID == order.OrderID && p.ProductID == productId).FirstOrDefault();
            if (order!=null)
            {
                if (orderDetail!=null)
                {
                    orderDetail.Count--;
                    order.SumAmount -= orderDetail.Price;
                    _context.SaveChanges();
                }
            }
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void UpdateOrderSumAmount(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            order.SumAmount = _context.OrderDetails.Where(p => p.OrderID == orderId).Sum(p=>p.Price*p.Count);
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}
