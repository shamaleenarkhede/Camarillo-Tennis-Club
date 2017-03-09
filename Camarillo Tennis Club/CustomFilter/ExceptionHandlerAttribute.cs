using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Camarillo_Tennis_Club.Models;
using System.Web.Mvc;

namespace Camarillo_Tennis_Club.CustomFilter
{
    public class ExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {


                ExceptionLogger logger = new ExceptionLogger()
                {
                    ExceptionMessage = filterContext.Exception.Message,
                    ExceptionStackTrace = filterContext.Exception.StackTrace,
                    ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                    LogTime = DateTime.Now
                };

                ExceptionDBContext exceptionDBContext = new ExceptionDBContext();
                exceptionDBContext.InsertExceptions(logger);

                filterContext.ExceptionHandled = true;
            }
        }
    }
}
    