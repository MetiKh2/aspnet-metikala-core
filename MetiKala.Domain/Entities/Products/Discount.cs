using MetiKala.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Domain.Entities.Products
{
  public  class Discount
    {
        [Key]
        public int DiscountID { get; set; }

        [Required]
        [MaxLength(150)]
        public string DiscountCode { get; set; }

        [Required]
        public int DiscountPercent { get; set; }

        public int? CountUse { get; set; }
        public bool IsRemoved { get; set; } = false;

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        #region Rel

        public List<ProductDiscount> ProductDiscounts { get; set; }
        public List<UserDiscount> UserDiscounts { get; set; }
        #endregion



    }
}
