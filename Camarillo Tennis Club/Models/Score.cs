using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Camarillo_Tennis_Club.Models
{
    public class Score
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Matches")]
        public int MatchID { get; set; }
        [ForeignKey("Players")]
        public int PlayerID { get; set; }

        [Required(ErrorMessage = "Please enter you Score")]
        [Range(0, 7, ErrorMessage = "Enter number between 0 to 7")]
        public int Set1Score { get; set; }

        [Required(ErrorMessage = "Please enter you Score")]
        [Range(0, 7, ErrorMessage = "Enter number between 0 to 7")]
        public int Set2Score { get; set; }

        [Required(ErrorMessage = "Please enter you Score")]
        [Range(0, 7, ErrorMessage = "Enter number between 0 to 7")]
        public int Set3Score { get; set; }

        public virtual ICollection<Players> Players { get; set;}

        public virtual Matches Matches { get; set;}

        public int ScoreValue { get; set; }

    
    }

   
}