using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Camarillo_Tennis_Club.Models
{
    public class Players
    {
        [ScaffoldColumn(false)]
        public int PlayerID { get; set; }

        [StringLength(25),Display(Name = "Enter First Name")]
        public string FName { get; set; }
        [StringLength(25), Display(Name = "Enter Last Name")]
        public string LName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BDate { get; set; }
        
    }
}