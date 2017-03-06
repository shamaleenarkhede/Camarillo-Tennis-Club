using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


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
       

        [Display(Name = "Select Player - 2")]
        public int Player2ID { get; set; }
       

        [Display(Name = "Winner")]
        public int PlayerID { get; set; }
       

        public virtual ICollection<Players> Players { get; set; }
    }

   
}