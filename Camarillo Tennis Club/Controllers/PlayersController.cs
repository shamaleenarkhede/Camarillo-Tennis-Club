using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using Camarillo_Tennis_Club.Models;

namespace Camarillo_Tennis_Club.Controllers
{
    public class PlayersController : Controller
    {
        // GET: Players
        public ActionResult Index()
        {
            if (Convert.ToString(Session["Role"]) == "Admin")
            {
                PlayersDBContext playersDBContext = new PlayersDBContext();
                DataSet dsPlayers = new DataSet();
                dsPlayers = playersDBContext.GetPlayersDetails();
                Players players = new Players();
                List<Players> playersList = new List<Players>();
                for (int i = 0; i < dsPlayers.Tables[0].Rows.Count; i++)
                {
                    players = new Players();
                    players.PlayerID = Convert.ToInt32(dsPlayers.Tables[0].Rows[i]["PlayerID"]);
                    players.FirstName = Convert.ToString(dsPlayers.Tables[0].Rows[i]["FirstName"]);
                    players.LastName = Convert.ToString(dsPlayers.Tables[0].Rows[i]["LastName"]);
                    players.BDate = Convert.ToDateTime(Convert.ToString(dsPlayers.Tables[0].Rows[i]["BirthDate"]));
                    playersList.Add(players);
                }
                players.playersList = playersList;
                return View(players);
            }
            else
            {
                return View("~/Views/PageNotFound.cshtml");
            }

        }

        // GET: Players/Create
        public ActionResult Create()
        {
            if (Convert.ToString(Session["Role"]) == "Admin")
            {
                return View();
            }
            else
            {
                return View("~/Views/PageNotFound.cshtml");
            }

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
                if (Convert.ToString(Session["Role"]) == "Admin")
                {
                    if (ModelState.IsValid)
                    {
                        PlayersDBContext playersDBContext = new PlayersDBContext();
                        int exists = playersDBContext.CheckPlayerExists(players);
                        if (exists == 1)    // Check if player already exists
                        {
                            ViewBag.Text = "Player exists Already!!!!";
                            return RedirectToAction("RecordExists");
                        }
                        else if (exists == 0)
                        {
                            int result = playersDBContext.InsertPlayerDetails(players);
                            return RedirectToAction("Save");
                        }

                    }
                    return View(players);
                }
                else
                {
                    return View("~/Views/PageNotFound.cshtml");
                }
                
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

        public ActionResult RecordExists()
        {
            return View();
        }

        public ActionResult Save()
        {
            return View();
        }

    }
}
