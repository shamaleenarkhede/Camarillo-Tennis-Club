using System;
using System.ComponentModel.DataAnnotations;

namespace Camarillo_Tennis_Club.Models
{
    public class Players
    {
        [Key]
        [ScaffoldColumn(false)]
        public int PlayerID { get; set; }

        [StringLength(25),Display(Name = "Enter Player Name")]
        public string PlayerName { get; set; }

        [DataType(DataType.Date), Display(Name = "Enter Birth Date")]
        public DateTime BDate { get; set; }
        
    }

}