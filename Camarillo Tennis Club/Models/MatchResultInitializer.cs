using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;


namespace Camarillo_Tennis_Club.Models
{
    public class MatchResultInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MatchResultContext>
    {
            protected override void Seed(MatchResultContext context)
            {
                var players = new List<Players>
            {
            new Players { FirstName = "Roger", LastName = "Fedrer", BDate = DateTime.Parse("01/25/1986") },
            new Players { FirstName = "Serena", LastName = "Williams", BDate = DateTime.Parse("09/14/1987") },
            new Players { FirstName = "Rafel", LastName = " Nadal", BDate = DateTime.Parse("12/24/1985") },
            new Players { FirstName = "Novak", LastName = " Djokovic", BDate = DateTime.Parse("03/04/1991") },
            new Players { FirstName = "Maria ", LastName = " Sharapova", BDate = DateTime.Parse("07/25/1954") }
            };

                players.ForEach(p => context.Player.AddOrUpdate(pl => pl.LastName, p));
                context.SaveChanges();

                var matches = new List<Matches>
            {
            new Matches {Location = "Camarillo", MatchDate = DateTime.Parse("03/07/2017"),Player1ID = 1, Player2ID = 3, WinnerID = 1},
            new Matches {Location = "Camarillo", MatchDate = DateTime.Parse("03/06/2017"),Player1ID = 2, Player2ID = 4, WinnerID = 2},
            new Matches {Location = "Camarillo", MatchDate = DateTime.Parse("03/08/2017"),Player1ID = 4, Player2ID = 5, WinnerID = 5}

            };
                matches.ForEach(m => context.Match.Add(m));
                context.SaveChanges();

                var scores = new List<Score>
            {
            new Score {MatchID = 1, PlayerID = 1, Set1Score = 0, Set2Score = 3, Set3Score = 2 },
            new Score {MatchID = 1, PlayerID = 3, Set1Score = 1, Set2Score = 5, Set3Score = 3 },
            new Score {MatchID = 2, PlayerID = 2, Set1Score = 1, Set2Score = 3, Set3Score = 5 },
            new Score {MatchID = 2, PlayerID = 4, Set1Score = 0, Set2Score = 2, Set3Score = 2 }
            };

                scores.ForEach(s => context.Scores.Add(s));
                context.SaveChanges();
            }
        }
    }
