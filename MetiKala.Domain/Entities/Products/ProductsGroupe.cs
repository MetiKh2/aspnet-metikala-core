using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Domain.Entities.Products
{
    public class ProductsGroupe
    {
        [Key]
        public int GroupeID { get; set; }
        [Display(Name = "نام گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string GroupeTitle { get; set; }
        [Display(Name = "گروه پدر")]
        public int? ParentID { get; set; }


        public bool IsRemoved { get; set; } = false;

        #region Rel
        [ForeignKey("ParentID")]
        public List<ProductsGroupe> ParentGroupes { get; set; }

        [InverseProperty("SubGroupe")]
        public List<Product> SubProducts { get; set; }
        [InverseProperty("ParentGroupe")]
        public List<Product> ParentProducts { get; set; }
        [InverseProperty("GrandParentGroupe")]
        public List<Product> GrandParentProducts { get; set; }

        #endregion
    }
}
