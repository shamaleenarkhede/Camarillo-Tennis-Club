using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Camarillo_Tennis_Club.Models
{
    public class MatchesViewModel
    {
    }

    public class AddNewMatchViewModel
    {
        [Display(Name ="Event Location:")]
        public string Location { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Event Date:")]
        public DateTime MatchDate { get; set; }
      
        public List<SelectListItem> playerNames { get; set; }

        [Display(Name = "Select Player - 1")]
        public int Player1ID { get; set; }   
        public string Player1Name { get; set; }

        [Display(Name = "Select Player - 2")]
        public int Player2ID { get; set; }
        public string Player2Name { get; set; }


    }

    public class EditMatchViewModel
    {
        [Display(Name = "Match:")]
        public string MatchName { get; set; }
        public int MatchID { get;}

        [Display(Name = "Event Location:")]
        public string Location { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Event Date:")]
        public DateTime MatchDate { get; set; }

        public List<SelectListItem> playerNames { get; set; }

        [Display(Name = "Select Player - 1")]
        public int Player1ID { get; set; }

        [Display(Name = "Select Player - 2")]
        public int Player2ID { get; set; }

    }
}