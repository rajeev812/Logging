using LoggingEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoggingEntityFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            throw new HttpException(404, "404 exception", new Exception("404 custom inner exception"));
            //throw new Exception("custom exception",new Exception("inner exception"));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult PostSample(int id)
        {
            return View();
        }
    }
}