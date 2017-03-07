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
    public class ScoresController : Controller
    {
        private MatchResultContext db = new MatchResultContext();

        // GET: Scores
        public ActionResult Index()
        {
            //var scores = db.Scores.Include(s => s.Matches);
            //return View(scores.ToList());
            return View();
        }

        // GET: Scores/Details/5
        public ActionResult Details(int id)
        {
            List<Score> scoresList = new List<Score>();
            ScoresDBContext scoresDBContext = new ScoresDBContext();
            DataSet dsMatchPlayerScores = new DataSet();
            dsMatchPlayerScores = scoresDBContext.GetMatchPlayersScores(id);
            Matches matches = new Matches();
            matches.Location = Convert.ToString(dsMatchPlayerScores.Tables[0].Rows[0]["Location"]);
            matches.MatchDate = Convert.ToDateTime(dsMatchPlayerScores.Tables[0].Rows[0]["MatchDate"]);
            matches.Player1Name = Convert.ToString(dsMatchPlayerScores.Tables[0].Rows[0]["Player1Name"]);
            matches.Player2Name = Convert.ToString(dsMatchPlayerScores.Tables[0].Rows[0]["Player2Name"]);
            matches.WinnerName = Convert.ToString(dsMatchPlayerScores.Tables[0].Rows[0]["WinnerName"]);
            for (int i = 0; i < dsMatchPlayerScores.Tables[0].Rows.Count; i++)
            {
                Score score = new Score();
                score.Set1Score= Convert.ToInt32(dsMatchPlayerScores.Tables[0].Rows[i]["Set1Score"]);
                score.Set2Score = Convert.ToInt32(dsMatchPlayerScores.Tables[0].Rows[i]["Set2Score"]);
                score.Set3Score = Convert.ToInt32(dsMatchPlayerScores.Tables[0].Rows[i]["Set3Score"]);
                scoresList.Add(score);
            }
            matches.scoreList = scoresList;
            
            return View(matches);
        }

        //// GET: Scores/Create
        //public ActionResult Create()
        //{
        //    ViewBag.MatchID = new SelectList(db.Match, "MatchID", "Location");
        //    return View();
        //}

        //// POST: Scores/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,MatchID,PlayerID,Set1Score,Set2Score,Set3Score")] Score score)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Scores.Add(score);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.MatchID = new SelectList(db.Match, "MatchID", "Location", score.MatchID);
        //    return View(score);
        //}

        //// GET: Scores/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Score score = db.Scores.Find(id);
        //    if (score == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.MatchID = new SelectList(db.Match, "MatchID", "Location", score.MatchID);
        //    return View(score);
        //}

        //// POST: Scores/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,MatchID,PlayerID,Set1Score,Set2Score,Set3Score")] Score score)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(score).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.MatchID = new SelectList(db.Match, "MatchID", "Location", score.MatchID);
        //    return View(score);
        //}

        //// GET: Scores/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Score score = db.Scores.Find(id);
        //    if (score == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(score);
        //}

        //// POST: Scores/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Score score = db.Scores.Find(id);
        //    db.Scores.Remove(score);
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
    }
}
