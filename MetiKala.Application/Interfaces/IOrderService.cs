using MetiKala.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Application.Interfaces
{
  public  interface IOrderService
    {
        #region Order
        int AddOrder(string username,int productId);
        void UpdateOrderSumAmount(int orderId);
        Order GetCurrentCart(string username);
        void MinusOrderDetail(string username,int productId);
        Order GetOrderByID(string username,int id);
        void UpdateOrder(Order order);
        List<Order> GetOrderByUserName(string username);
        #endregion
    }
}
