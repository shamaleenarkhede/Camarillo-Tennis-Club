using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Camarillo_Tennis_Club.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Convert.ToString(Session["Role"])== "Admin")
            {
                return RedirectToAction("AdminHome","Login");
            }
            else { 
            return View();
            }
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
    }
}