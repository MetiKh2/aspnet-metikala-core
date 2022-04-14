using MetiKala.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Domain.Entities.Products
{
   public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public int ParentGroupeID { get; set; }
     
        public int? GrandParentGroupeID { get; set; }
     
        public int? SubGroupeID { get; set; }
        [Display(Name = "نام کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ProductTitle { get; set; }
        [Display(Name = "قیمت")]
        public int Price { get; set; }
        [Display(Name = "توضیحات ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(1500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Description { get; set; }
        [Display(Name = "تصویر ")]
        public string Image { get; set; }

        public bool IsRemoved { get; set; }

        #region Rel

        [ForeignKey("ParentGroupeID")]
        public ProductsGroupe ParentGroupe { get; set; }
        [ForeignKey("SubGroupeID")]
        public ProductsGroupe SubGroupe { get; set; }
        [ForeignKey("GrandParentGroupeID")]
        public ProductsGroupe GrandParentGroupe { get; set; }

        public List<ProductFeature> ProductFeatures { get; set; }
        public List<ProductDiscount> ProductDiscounts { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        #endregion
    }
}
