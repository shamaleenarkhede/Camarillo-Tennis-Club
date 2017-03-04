using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Camarillo_Tennis_Club.Models
{
    public class Matches
    {

        [Key]
        [ScaffoldColumn(false)]
        public int MatchID { get; set; }

        [Display(Name = "Event Location:")]
        public string Location { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Event Date:")]
        public DateTime MatchDate { get; set; }

        [Display(Name = "Select Player - 1")]
        public int Player1ID { get; set; }
        public string Player1Name { get; set; }

        [Display(Name = "Select Player - 2")]
        public int Player2ID { get; set; }
        public string Player2Name { get; set; }

        [Display(Name = "Winner")]
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }

        public virtual Players Players { get; set; }
    }
}