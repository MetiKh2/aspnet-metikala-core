using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Domain.Entities.Products
{
   public class ProductFeature
    {
        [Key]
        public int FeatureID { get; set; }
        [Display(Name = "ویژگی ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Display { get; set; }
        [Display(Name = "مقدار ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Value { get; set; }
        [Required]
        public int ProductID { get; set; }

        #region Rel

        public Product Product { get; set; }
        #endregion
    }
}
