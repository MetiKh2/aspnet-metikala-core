using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Application.DTOs.Role
{
   public class EditRoleViewModel
    {
        public int RoleID { get; set; }
        public string LastRoleTitle { get; set; }
        [Display(Name = "نام  نقش  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string NewRoleTitle { get; set; }
    }
}
