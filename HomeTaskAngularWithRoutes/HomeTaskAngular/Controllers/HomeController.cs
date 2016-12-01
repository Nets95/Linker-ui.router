using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeTaskAngular.Models;
using DAL.Abstraction.Repository;
using DAL.Cocreate.Repository;
using System.Configuration;
using Newtonsoft.Json;
using LinkEntities.LinkEntity;

namespace HomeTaskAngular.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {    
            return View();
        }

        [HttpGet]
        public JsonResult GetAllLinks()
        {
            IOperations operation = new Operations(ConfigurationManager.ConnectionStrings["LinksDbConnection"].ConnectionString);
            var links = operation.GetAllLinks();
            JsonConvert.SerializeObject(links);
            return Json(links, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult RemooveLink(LinkEntity link)
        {
            IOperations operation = new Operations(ConfigurationManager.ConnectionStrings["LinksDbConnection"].ConnectionString);
            var deletedLink = operation.Remoove(link);
            JsonConvert.SerializeObject(deletedLink);
            return Json(deletedLink);
        }

        [HttpPost]
        public ActionResult AddLink(LinkEntity link)
        {
            IOperations operation = new Operations(ConfigurationManager.ConnectionStrings["LinksDbConnection"].ConnectionString);
            var adedLink = operation.Add(link);
            JsonConvert.SerializeObject(adedLink);
            return Json(adedLink);
        }


        [HttpPost]      
        public ActionResult UpdateLink(LinkEntity link, string editLinkTitle)
        {
            IOperations operation = new Operations(ConfigurationManager.ConnectionStrings["LinksDbConnection"].ConnectionString);
            var updatedLink = operation.Update(link, editLinkTitle);
            JsonConvert.SerializeObject(updatedLink);
            return Json(updatedLink);
        }

    }
}