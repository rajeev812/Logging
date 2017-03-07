using LoggingEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LoggingEntityFramework
{
    public class MvcApplication : System.Web.HttpApplication
    {
        ProductContext db = new ProductContext();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            ExceptionLogger logger = new ExceptionLogger
            {
                Id = Guid.NewGuid(),
                ExceptionMessage = exception.Message,
                ControllerName = "",
                ExceptionStackTrace = exception.StackTrace,
                LogTime = DateTime.Now
            };

            db.ExceptionLoggers.Add(logger);
            db.SaveChanges();

            Server.ClearError();
            Response.Redirect("~/Error/Default");
        }
    }
}
