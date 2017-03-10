using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web.Mvc;
using Camarillo_Tennis_Club.Models;
using Camarillo_Tennis_Club.CustomFilter;

namespace Camarillo_Tennis_Club.Controllers
{

    public class MatchesController : Controller
    {
     

        // GET: Matches
        [ExceptionHandler]
        public ActionResult Index()
        {
            try
            {
                    MatchesDBContext matchesDBContext = new MatchesDBContext();
                    DataSet dsMatchesPlayers = new DataSet();
                    dsMatchesPlayers = matchesDBContext.GetMatchesPlayers();
                
                    Matches matches = new Matches();
                    matches = getMatchResults(dsMatchesPlayers);
                    return View(matches);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Matches", "Index"));
            }
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
        [ExceptionHandler]
        public ActionResult Create()
        {
            try { 
            if (Convert.ToString(Session["Role"]) == "Admin")
            {
                // Populate the dropdownlists
                Matches matches = new Matches();
                matches.playerNames = getPlayersList();
                matches.MatchDate = DateTime.Now;
                return View(matches);
            }
            else
            {
                return View("~/Views/PageNotFound.cshtml");
            }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Matches", "Create"));
            }

        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ExceptionHandler]
        public ActionResult Create(Matches matches)
        {
            try
            {
                if (matches.WinnerID == matches.Player1ID || matches.WinnerID == matches.Player2ID)
                {
                    if (ModelState.IsValid)
                    {
                        MatchesDBContext matchesDBContext = new MatchesDBContext();
                        int MatchID = matchesDBContext.InsertMatchDetails(matches);
                        matches.MatchID = MatchID;
                        ScoresDBContext scoresDBContext = new ScoresDBContext();
                        int result = scoresDBContext.InsertScores(matches);
                        if (result == 1 || result == -1)
                        {
                            return RedirectToAction("Save");
                        }
                    }
                    return RedirectToAction("Index");
                }
              
                else
                {
                    matches.playerNames = getPlayersList();
                    return View(matches);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Matches", "Create"));
            }

        }

        // GET: Matches/Edit/5
        [HandleError]
        public ActionResult Edit(int id)
        {
            try
            {
                if (Convert.ToString(Session["Role"]) == "Admin")
                {
                    TempData["MatchID"] = id;
                    Matches matches = new Matches();
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
                else
                {
                    return View("~/Views/PageNotFound.cshtml");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Matches", "Edit"));
            }
        }

        // POST: Matches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult Edit(Matches matches)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    matches.MatchID = Convert.ToInt32(TempData["MatchID"]);
                    ScoresDBContext scoresDBContext = new ScoresDBContext();
                    scoresDBContext.UpdateScores(matches);
                    MatchesDBContext matchesDBContext = new MatchesDBContext();
                    int result = matchesDBContext.UpdateMatchDetails(matches);
                    if (result == 1)
                    {
                        return RedirectToAction("Save");
                    }
                    return RedirectToAction("Index");
                }
                return View(matches);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Matches", "Edit"));
            }
        }

        //// GET: Matches/Delete/5
        public ActionResult Search()
        {
            return View();
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Search")]
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult Search(SearchViewModel searchViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string searchString = "";
                    searchString = searchViewModel.SearchString;
                    DateTime? searchDate = searchViewModel.SearchDate;
                    TempData["searchString"] = searchString;
                    TempData["searchDate"] = searchDate;
                    return RedirectToAction("SearchResults");
                }
                else
                { return View(); }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Matches", "Search"));
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
              //  db.Dispose();
            }
            base.Dispose(disposing);
        }

        public List<Players> getPlayersList()
        {
            try
            {
                List<Players> playersList = new List<Players>();
                PlayersDBContext playersDBContext = new PlayersDBContext();
                DataSet ds = playersDBContext.GetPlayers();

                foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
                {
                    playersList.Add(new Players { PlayerID = Convert.ToInt32(@dr["PlayerID"]), FirstName = @dr["FirstName"].ToString(), LastName = @dr["LastName"].ToString() });
                }

                return playersList;
            }
            catch (Exception ex)
            {
                new HandleErrorInfo(ex, "Matches", "Create");
                return null;
            }
        }

        [HandleError]
        public Matches getMatchResults(DataSet ds)
        {
            try
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
            catch (Exception ex)
            {
                new HandleErrorInfo(ex, "Matches", "Create");
                return null;
            }

        }

        [ActionName("SearchResults")]
        [HandleError]
        public ActionResult SearchResults(SearchViewModel searchViewModel)
        {
            try
            {
                string searchString = Convert.ToString(TempData["searchString"]);
                DateTime searchDate = Convert.ToDateTime(TempData["searchDate"]);
                MatchesDBContext matchesDBContext = new MatchesDBContext();
                DataSet dsResult = new DataSet();
                dsResult = matchesDBContext.GetMatchUsingSearchString(searchString,searchDate);
                Matches objMatches = new Matches();
                objMatches = getMatchResults(dsResult);
                if (objMatches != null)
                {

                    return View(objMatches);
                }
                else
                {
                    return RedirectToAction("Search", "Matches", "Please enter valid data");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Matches", "Search"));
            }

        }

        public ActionResult Save()
        {
            return View();
        }
       

    }

    
}
