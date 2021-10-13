using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(MyViewModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Priority = model.Priority;
                ViewBag.DateStart = model.DateStart;
                ViewBag.DateEnd = model.DateEnd;
                ViewBag.ErrorMessage = IsValid(model);
             }
            return View(model);
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
        public string IsValid(MyViewModel model)
        {
            int dtRange = model.DateEnd - model.DateStart;
            if (model.Priority > 0 && model.DateStart > 0 && model.DateEnd > 0)
            {
                if (dtRange < 0) return "DateEnd should be greater than DateStart.";
                if ((model.Priority < 1000) && (dtRange >= 90))
                {
                    return "Date range should be under 90 days";
                }
                else if((model.Priority >= 1000 && model.Priority <= 5000) && (dtRange <90 || dtRange > 180))
                {
                    return "Date range should be between 90 and 180 days";
                }
                else if ((model.Priority > 5000) && (dtRange <= 180))
                {
                    return "Date range should be more than 180 days";
                }
                else
                {
                    return string.Empty;
                }
            }
            return "Please enter valid value";
        }
    }
    

}