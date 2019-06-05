using AutoDealer.Core.Infrastucture;
using AutoDealer.Core.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoDealer.Web.Common
{
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            var ex = filterContext.Exception;
            ILogger logger = ServiceContainer.Resolve<ILogger>();
            logger.Error("Found Unhandled Exception:", ex);
        }
    }
}