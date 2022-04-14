using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Domain.Entities.Order
{
  public  class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int SumAmount { get; set; }

        public bool IsFinally { get; set; } = false;

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public OrderState OrderState { get; set; } = OrderState.NotPayment;

        #region Rel
        public List<OrderDetail> OrderDetails { get; set; }
        public User.User User { get; set; }
        #endregion
    }

    public enum OrderState
    {
        Delivered=1,
        Processing=2,
        Canceled=3,
        NotPayment=4
    }
}
