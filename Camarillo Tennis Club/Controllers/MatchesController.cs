using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
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
            MatchesDBContext matchesDBContext = new MatchesDBContext();
            DataSet dsMatchesPlayers = new DataSet();
            dsMatchesPlayers = matchesDBContext.GetMatchesPlayers();
            Matches matches = new Matches();
            matches = getMatchResults(dsMatchesPlayers);
            return View(matches);
        }

        // GET: Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction("Details", "Scores", new { id = "" });
          //  return View(matches);
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
                "ID", "Name",0);

            ViewData["list"] = list;

            return View(addNewMatchViewModel);
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddNewMatchViewModel addNewMatchViewModel)
        {
            if (ModelState.IsValid)
            {
                MatchesDBContext matchesDBContext = new MatchesDBContext();
                int MatchID=matchesDBContext.InsertMatchDetails(addNewMatchViewModel);
                addNewMatchViewModel.MatchID = MatchID;
                ScoresDBContext scoresDBContext = new ScoresDBContext();
                scoresDBContext.InsertScores(addNewMatchViewModel);
                return RedirectToAction("Index");
            }

            return View(addNewMatchViewModel);
        }

        // GET: Matches/Edit/5
        public ActionResult Edit(int id)
        {
            TempData["MatchID"] = id;
            Matches matches = new Matches();
            matches.SetScores = new List<SelectListItem>
            {
                new SelectListItem{ Text = "0", Value = "0" },
                new SelectListItem{Text = "1", Value = "1" },
                new SelectListItem{ Text = "2", Value = "2"},
                new SelectListItem{ Text = "3", Value = "3" },
                new SelectListItem{ Text = "4", Value = "4"},
                new SelectListItem{Text = "5", Value = "5"},
                new SelectListItem{ Text = "6", Value = "6"},
                new SelectListItem{ Text = "7", Value = "7" }
            };
          
            List<Score> scoresList = new List<Score>();
            ScoresDBContext scoresDBContext = new ScoresDBContext();
            DataSet dsMatchPlayerScores = new DataSet();
            dsMatchPlayerScores = scoresDBContext.GetMatchPlayersScores(id);
            matches.playerNames = getPlayersList();
            matches.Location = Convert.ToString(dsMatchPlayerScores.Tables[0].Rows[0]["Location"]);
            matches.MatchDate = Convert.ToDateTime(dsMatchPlayerScores.Tables[0].Rows[0]["MatchDate"]);
            matches.Player1ID = Convert.ToInt32(dsMatchPlayerScores.Tables[0].Rows[0]["Player1ID"]);
            matches.Player2ID = Convert.ToInt32(dsMatchPlayerScores.Tables[0].Rows[0]["Player2ID"]);
            matches.WinnerID = Convert.ToInt32(dsMatchPlayerScores.Tables[0].Rows[0]["WinnerID"]);
            matches.Player1Name = Convert.ToString(dsMatchPlayerScores.Tables[0].Rows[0]["Player1Name"]);
            matches.Player2Name = Convert.ToString(dsMatchPlayerScores.Tables[0].Rows[0]["Player2Name"]);
            matches.WinnerName = Convert.ToString(dsMatchPlayerScores.Tables[0].Rows[0]["WinnerName"]);
            for (int i = 0; i < dsMatchPlayerScores.Tables[0].Rows.Count; i++)
            {
                Score score = new Score();
                score.Set1Score = Convert.ToInt32(dsMatchPlayerScores.Tables[0].Rows[i]["Set1Score"]);
                score.Set2Score = Convert.ToInt32(dsMatchPlayerScores.Tables[0].Rows[i]["Set2Score"]);
                score.Set3Score = Convert.ToInt32(dsMatchPlayerScores.Tables[0].Rows[i]["Set3Score"]);
                scoresList.Add(score);
            }
            matches.scoreList = scoresList;
            return View(matches);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Matches matches)
        {
            if (ModelState.IsValid)
            {
                matches.MatchID = Convert.ToInt32(TempData["MatchID"]);
                ScoresDBContext scoresDBContext = new ScoresDBContext();
                scoresDBContext.UpdateScores(matches);
                MatchesDBContext matchesDBContext = new MatchesDBContext();
                matchesDBContext.UpdateMatchDetails(matches);
                return RedirectToAction("Index");
            }
            return View(matches);
        }

        //// GET: Matches/Delete/5
        public ActionResult Search()
        {
            return View();
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Search")]
        [ValidateAntiForgeryToken]
        public ActionResult Search(Matches matches)
        {
            string searchString = matches.Location;
            MatchesDBContext matchesDBContext = new MatchesDBContext();
            DataSet dsResult = new DataSet();
            dsResult = matchesDBContext.GetMatchUsingSearchString(searchString);
            Matches objMatches = new Matches();
            objMatches = getMatchResults(dsResult);
            return RedirectToAction("SearchResults", objMatches);
        }

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

        public Matches getMatchResults(DataSet ds)
        {
            Matches matches = new Matches();
            List<Matches> matchesList = new List<Matches>();
          
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                matches = new Matches();
                matches.MatchID = Convert.ToInt32(ds.Tables[0].Rows[i]["MatchID"]);
                matches.Location = Convert.ToString(ds.Tables[0].Rows[i]["Location"]);
                matches.MatchDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["MatchDate"]);
                matches.Player1ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Player1ID"]);
                matches.Player2ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Player1ID"]);
                matches.Player1Name = Convert.ToString(ds.Tables[0].Rows[i]["Player1Name"]);
                matches.Player2Name = Convert.ToString(ds.Tables[0].Rows[i]["Player2Name"]);
                matches.WinnerName = Convert.ToString(ds.Tables[0].Rows[i]["WinnerName"]);
                matchesList.Add(matches);
            }
            matches.matchesList = matchesList;
            return matches;

        }

        [ActionName("SearchResults")]
        public ActionResult SearchResults(Matches matches)
        {
            string searchString = matches.Location;
            MatchesDBContext matchesDBContext = new MatchesDBContext();
            DataSet dsResult = new DataSet();
            dsResult = matchesDBContext.GetMatchUsingSearchString(searchString);
            Matches objMatches = new Matches();
            objMatches = getMatchResults(dsResult);
           
            return View(objMatches);
        }
       

    }

    
}
