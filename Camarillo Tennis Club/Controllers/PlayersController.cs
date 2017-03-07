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
        private MatchResultContext db = new MatchResultContext();

        // GET: Players
        public ActionResult Index()
        {
            PlayersDBContext playersDBContext = new PlayersDBContext();
            return View(db.Player.ToList());
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Players players = db.Player.Find(id);
            if (players == null)
            {
                return HttpNotFound();
            }
            return View(players);
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
        public ActionResult Create(Players players)
        {
            if (ModelState.IsValid)
            {
                PlayersDBContext playersDBContext = new PlayersDBContext();
                playersDBContext.InsertPlayerDetails(players);
                return RedirectToAction("Index");
            }

            return View(players);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Players players = db.Player.Find(id);
            ViewBag.BDate = players.BDate.Date;
            if (players == null)
            {
                return HttpNotFound();
            }            
            
            return View(players);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerID,FirstName, LastName,BDate")] Players players)
        {
            if (ModelState.IsValid)
            {
                db.Entry(players).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(players);
        }

        // GET: Players/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Players players = db.Player.Find(id);
        //    if (players == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(players);
        //}

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Players players = db.Player.Find(id);
            db.Player.Remove(players);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
