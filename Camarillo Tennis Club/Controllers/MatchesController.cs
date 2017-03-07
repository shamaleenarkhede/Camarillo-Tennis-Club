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

    public class MatchesController : Controller
    {
        private MatchResultContext db = new MatchResultContext();

        // GET: Matches
        public ActionResult Index()
        {
            return View();
           // return View(db.Match.ToList());
        }

        // GET: Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matches matches = db.Match.Find(id);
            if (matches == null)
            {
                return HttpNotFound();
            }
            return View(matches);
        }

        // GET: Matches/Create
        public ActionResult Create()
        {
            // Populate the dropdownlists

            AddNewMatchViewModel addNewMatchViewModel = new AddNewMatchViewModel();
            addNewMatchViewModel.playerNames = getPlayersList();

            var list = new SelectList(new[]
            {
                new { ID = "0", Name = "0" },
                new { ID = "1", Name = "1" },
                new { ID = "2", Name = "2" },
                new { ID = "3", Name = "3" },
                new { ID = "4", Name = "4" },
                new { ID = "5", Name = "5" },
                new { ID = "6", Name = "6" },
                new { ID = "7", Name = "7" }
            },
                "ID", "Name", 0);

            ViewData["list"] = list;

            return View(addNewMatchViewModel);
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddNewMatchViewModel matches)
        {
            if (ModelState.IsValid)
            {
                MatchesDBContext matchesDBContext = new MatchesDBContext();
                int MatchID=matchesDBContext.InsertMatchDetails(matches);
                matches.MatchID = MatchID;
                ScoresDBContext scoresDBContext = new ScoresDBContext();
                scoresDBContext.InsertScores(matches);
                   
               
                return RedirectToAction("Index");
            }

            return View(matches);
        }

        // GET: Matches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matches matches = db.Match.Find(id);
            if (matches == null)
            {
                return HttpNotFound();
            }
            return View(matches);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchID,Location,MatchDate,Player1ID,Player2ID,WinnerID")] Matches matches)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matches).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(matches);
        }

        //// GET: Matches/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Matches matches = db.Match.Find(id);
        //    if (matches == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(matches);
        //}

        // POST: Matches/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Matches matches = db.Match.Find(id);
        //    db.Match.Remove(matches);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public List<Players> getPlayersList()
        {
            List<Players> playersList = new List<Players>();
            PlayersDBContext playersDBContext = new PlayersDBContext();
            DataSet ds = playersDBContext.GetPlayers();

            foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
            {
                playersList.Add(new Players { PlayerID = Convert.ToInt32(@dr["PlayerID"]), FirstName = @dr["FirstName"].ToString(),LastName = @dr["LastName"].ToString() });
            }

            return playersList;
        }
       

    }

    
}
