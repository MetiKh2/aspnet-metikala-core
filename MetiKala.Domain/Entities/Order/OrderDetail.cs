using MetiKala.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Domain.Entities.Order
{
   public class OrderDetail
    {
        [Key]
        public int OD_ID { get; set; }

        [Required]
        public int OrderID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int Price { get; set; }

        #region Rel
        public Order Order { get; set; }
        public Product Product { get; set; }
        #endregion
    }
}
