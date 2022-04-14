using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Application.DTOs.User
{
   public class ResetPasswordViewModel
    {
        public string Password { get; set; }
        public string RePassword { get; set; }
        public int UserID { get; set; }
    }
}
