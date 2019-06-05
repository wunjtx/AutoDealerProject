using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoDealer.Core.Utils
{
   public static class Check
    {
        //为空 非空验证
        public static bool IsEmpty(string value)
        {
            if (!string.IsNullOrEmpty(value))
                return false;
            return true;
        }
    }
}
