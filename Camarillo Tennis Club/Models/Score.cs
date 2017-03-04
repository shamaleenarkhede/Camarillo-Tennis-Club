using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Camarillo_Tennis_Club.Models
{
    public class Score
    {
        public int MatchID { get; set; }
        public int PlayerID { get; set; }
        public int Set1Score { get; set; }
        public int Set2Score { get; set; }
        public int Set3Score { get; set; }

        public virtual Players Players { get; set;}

        public virtual Matches Matches { get; set;}
    }
}