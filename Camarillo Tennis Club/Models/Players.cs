using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Camarillo_Tennis_Club.Models
{
    public class Players
    {
        [Key]
        [ScaffoldColumn(false)]
        public int PlayerID { get; set; }

        [StringLength(25), Display(Name = "Enter First Name")]
        public string FirstName { get; set; }

        [StringLength(25), Display(Name = "Enter Last Name")]
        public string LastName { get; set; }

        [ScaffoldColumn(false)]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }

        [DataType(DataType.Date), Display(Name = "Enter Birth Date")]
        public DateTime BDate { get; set; }

        public string MatchID { get; set; }

        public int Set1Score { get; set; }
        public int Set2Score { get; set; }
        public int Set3Score { get; set; }

        //    public List<Players> playersList { get; set; }

    }


}