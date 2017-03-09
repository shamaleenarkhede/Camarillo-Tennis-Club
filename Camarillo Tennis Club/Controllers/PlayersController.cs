using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Camarillo_Tennis_Club.Models;

namespace Camarillo_Tennis_Club.Controllers
{
    public class PlayersController : Controller
    {
      

        // GET: Players
        public ActionResult Index()
        {
            return View();
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
         
            return View();
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult Create(Players players)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PlayersDBContext playersDBContext = new PlayersDBContext();
                    playersDBContext.InsertPlayerDetails(players);
                    return RedirectToAction("Index");
                }

                return View(players);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Players", "Create"));
            }
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                
            }
            base.Dispose(disposing);
        }
    }
}
