using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Camarillo_Tennis_Club.Models
{
    public class Matches
    {

        [Key]
        [ScaffoldColumn(false)]
        public int MatchID { get; set; }

        [Display(Name = "Match Name")]
        public string MatchName
        {
            get { return Player1Name + "  VS  " + Player2Name; }
        }

        [Display(Name = "Event Location")]
        public string Location { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Event Date")]
        public DateTime MatchDate { get; set; }

        [ForeignKey("Players")]
        [Display(Name = "Select Player - 1")]
        public int Player1ID { get; set; }
        public string Player1Name { get; set; }

        [ForeignKey("Players")]
        [Display(Name = "Select Player - 2")]
        public int Player2ID { get; set; }
        public string Player2Name { get; set; }

        [ForeignKey("Players")]
        [Display(Name = "Winner")]
        public int WinnerID { get; set; }
        public string WinnerName { get; set; }
       

        public List<Matches> matchesList { get; set; }
        public List<Score> scoreList { get; set; }
        public List<Players> playerNames { get; set; }

        public IList<SelectListItem> SetScores { get; set; }
    }

   
}