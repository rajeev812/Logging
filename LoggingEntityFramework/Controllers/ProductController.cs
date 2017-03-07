using LoggingEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace LoggingEntityFramework.Controllers
{
    public class ProductController : Controller
    {
        ProductContext db = new ProductContext();
        List<List<string>> stringCollections = new List<List<string>>();
        
        public ActionResult Index()
        {
            db.Database.Log = l => Log(l);
            var products = db.Products.ToList();

            var xml = Serialize(stringCollections);
            
            return this.Content(xml,"text/xml");

            //return this.Content("<db></db>", "text/xml");
            //return Json(logs, JsonRequestBehavior.AllowGet);
        }

        private void Log(string l)
        {
            List<string> logs = new List<string>();
            logs.Add(l);
            stringCollections.Add(logs);
        }

        private string Serialize(List<List<string>> subReq)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<List<string>>));
            var xmlString = "";

            using (var stringWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
                {
                    serializer.Serialize(xmlWriter, subReq);
                    xmlString = stringWriter.ToString();
                }
            }
            return xmlString;
        }
    }
}