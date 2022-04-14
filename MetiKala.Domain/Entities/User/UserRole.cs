﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Domain.Entities.User
{
   public class UserRole
    {
        [Key]
        public int UR_ID { get; set; }

        public int UserID { get; set; }

        public int RoleID { get; set; }

        #region Rel
        public User User { get; set; }

        public Role Role { get; set; }
        #endregion
    }
}
