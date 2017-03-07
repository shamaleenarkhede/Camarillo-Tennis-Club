using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("Players")]
        [Display(Name = "Select Player - 1")]
        public int Player1ID { get; set; }

        [ForeignKey("Players")]
        [Display(Name = "Select Player - 2")]
        public int Player2ID { get; set; }

        [ForeignKey("Players")]
        [Display(Name = "Winner")]
        public int WinnerID { get; set; }
       

        public virtual ICollection<Players> Players { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }

   
}