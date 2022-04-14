using MetiKala.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Domain.Entities.User
{
   public class UserDiscount
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int DiscountID { get; set; }

        #region Rel
        public User User { get; set; }
        public Discount Discount { get; set; }

        #endregion
    }
}
