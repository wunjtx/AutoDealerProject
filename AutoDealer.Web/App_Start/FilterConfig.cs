using AutoDealer.Web.Common;
using System.Web;
using System.Web.Mvc;

namespace AutoDealer.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(filter : new CustomHandleErrorAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
