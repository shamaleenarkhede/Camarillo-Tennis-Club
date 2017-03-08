using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Camarillo_Tennis_Club.Validation_Attributes;

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
        [Required(ErrorMessage = "Event Location is required")]
        public string Location { get; set; }

        DateTime currentDate = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [ValidMatchDate(ErrorMessage = "Match Date can not be greater than current date")]
        [Required(ErrorMessage = "MatchDate is required")]
        [Display(Name = "Event Date")]
        public DateTime MatchDate { get; set; }

        [ForeignKey("Players")]
        [Display(Name = "Select Player - 1")]
        [Required(ErrorMessage = "Select Player-1")]
        public int Player1ID { get; set; }
        public string Player1Name { get; set; }

        [ForeignKey("Players")]
        [Display(Name = "Select Player - 2")]
        [Required(ErrorMessage = "Select Player-2")]
        [NotEqualTo("Player1ID", ErrorMessage = "Player-1 and Player-2 cannot be the same.")]
        public int Player2ID { get; set; }
        public string Player2Name { get; set; }

        [ForeignKey("Players")]
        [Display(Name = "Winner")]
        [Required(ErrorMessage = "Select Winner")]
        public int WinnerID { get; set; }
        public string WinnerName { get; set; }
       

        public List<Matches> matchesList { get; set; }
        public List<Score> scoreList { get; set; }
        public List<Players> playerNames { get; set; }
        
        public IList<SelectListItem> SetScores { get; set; }
        public List<Score> set1ScoreList { get; set; }
        public List<Score> set2ScoreList { get; set; }
        public List<Score> set3ScoreList { get; set; }


    }
   


}