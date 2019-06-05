using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Management;
using System.Web;

namespace AutoDealer.Core.Utils
{
  public static  class Tools
    {
      /// <summary>
      /// 获取mac地址
      /// </summary>
      /// <returns></returns>
      public  static string GetMac()
      {
          string stringMAC = "";
          // string stringIP = "";
          ManagementClass MC = new ManagementClass("Win32_NetworkAdapterConfiguration");
          ManagementObjectCollection MOC = MC.GetInstances();
          foreach (ManagementObject MO in MOC)
          {
              if ((bool)MO["IPEnabled"] == true)
              {
                  stringMAC += MO["MACAddress"].ToString().Replace(':', '-');
                  return stringMAC.ToString();

              }
          }
          return "";

      }
      /// <summary>
      /// 获取客户端ip地址
      /// </summary>
      /// <returns></returns>
      public  static string GetClientIP()
      {
          string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
          if (null == result || result == String.Empty)
          {
              result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
          }

          if (null == result || result == String.Empty)
          {
              result = HttpContext.Current.Request.UserHostAddress;
          }
          return result;
      }
      /// <summary>
      /// MD5加密
      /// </summary>
      /// <param name="password"></param>
      /// <returns></returns>
      public static String EncryptCode(string password)
      {
          Byte[] clearBytes = new UnicodeEncoding().GetBytes(password);
          Byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
          return BitConverter.ToString(hashedBytes).Replace("-", "");
      }

     
    }
}
