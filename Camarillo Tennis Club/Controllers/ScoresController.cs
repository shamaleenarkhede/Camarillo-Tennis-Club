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
        

        // GET: Scores
        public ActionResult Index()
        {
            return View();
        }

        // GET: Scores/Details/5
        [HandleError]
        public ActionResult Details(int id)
        {
            try
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
                    score.Set1Score = Convert.ToInt32(dsMatchPlayerScores.Tables[0].Rows[i]["Set1Score"]);
                    score.Set2Score = Convert.ToInt32(dsMatchPlayerScores.Tables[0].Rows[i]["Set2Score"]);
                    score.Set3Score = Convert.ToInt32(dsMatchPlayerScores.Tables[0].Rows[i]["Set3Score"]);
                    scoresList.Add(score);
                }
                matches.scoreList = scoresList;

                return View(matches);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Scores", "Index"));
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
