using LoggingEntityFramework.Models;
using System.Web;
using System.Web.Mvc;

namespace LoggingEntityFramework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorCustomAttribute());
        }
    }
}
