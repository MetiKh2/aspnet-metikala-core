using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Domain.Entities.Products
{
   public class ProductDiscount
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int ProductID { get; set; }

        [Required]
        public int DiscountID { get; set; }

        #region Rel
        public Discount Discount { get; set; }
        public Product Product { get; set; }
        #endregion
    }
}
