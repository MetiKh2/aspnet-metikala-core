﻿using MetiKala.Domain.Entities.Permission;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Domain.Entities.User
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        [Display(Name = "نام  نقش  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string RoleTitle { get; set; }

        [Display(Name = "حذف شده؟")]
        public bool IsRemoved { get; set; } = false;
        #region Rel
        public List<UserRole> UserRoles { get; set; }
        public List<RolePermission> RolePermissions { get; set; }
        #endregion
    }
}
