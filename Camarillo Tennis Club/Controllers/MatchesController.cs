using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Camarillo_Tennis_Club.Controllers
{
    public class MatchesController : Controller
    {
        // GET: Match
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNewMatch()
        {
            List<SelectListItem> ObjItem = new List<SelectListItem>()
            {
          new SelectListItem {Text="--Select Player--",Value="0",Selected=true },
          new SelectListItem {Text="PlayerB",Value="1" },
          new SelectListItem {Text="PlayerC",Value="2"},
          new SelectListItem {Text="PlayerD",Value="3"},
          new SelectListItem {Text="PlayerE",Value="4" },
            };
            ViewBag.ListItem = ObjItem;
            return View();
        }

        public ActionResult EditMatch()
        {
            List<SelectListItem> ObjItem = new List<SelectListItem>()
            {
          new SelectListItem {Text="--Select Player--",Value="0",Selected=true },
          new SelectListItem {Text="PlayerB",Value="1" },
          new SelectListItem {Text="PlayerC",Value="2"},
          new SelectListItem {Text="PlayerD",Value="3"},
          new SelectListItem {Text="PlayerE",Value="4" },
            };
            ViewBag.ListItem = ObjItem;
            return View();
        }
    }
}