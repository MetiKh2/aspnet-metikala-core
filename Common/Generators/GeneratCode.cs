using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Common.Convertors
{
  public static class GeneratCode
    {
        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-","");
        }
    }
}
