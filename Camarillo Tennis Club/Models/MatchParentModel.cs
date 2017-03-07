using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Camarillo_Tennis_Club.Models
{
    public class MatchParentModel
    {
        public Matches Matches { get; set; }
        public Players Players { get; set; }
        public Score Scores { get; set; }
    }
}