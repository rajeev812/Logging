using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoggingEntityFramework.Models
{
    public class HandleErrorCustomAttribute : HandleErrorAttribute
    {
        ProductContext db = new ProductContext();
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                ExceptionLogger logger = new ExceptionLogger
                {
                    Id = Guid.NewGuid(),
                    ExceptionMessage = filterContext.Exception.Message,
                    ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                    ExceptionStackTrace = filterContext.Exception.StackTrace,
                    LogTime = DateTime.Now
                };

                db.ExceptionLoggers.Add(logger);
                db.SaveChanges();

                filterContext.ExceptionHandled = true;

                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml"
                };
            }
        }
    }
}