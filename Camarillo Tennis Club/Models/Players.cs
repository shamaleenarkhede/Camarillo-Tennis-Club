using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Camarillo_Tennis_Club.Validation_Attributes;

namespace Camarillo_Tennis_Club.Models
{
    public class Players
    {
        [Key]
        [ScaffoldColumn(false)]
        public int PlayerID { get; set; }

        [Required(ErrorMessage ="Player First Name required")]
        [StringLength(25), Display(Name = "Enter First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Player Last Name required")]
        [StringLength(25), Display(Name = "Enter Last Name")]
        public string LastName { get; set; }

        [ScaffoldColumn(false)]
        public string FullName
        {
            get { return LastName + " " + FirstName; }
        }

        [Required(ErrorMessage = "Player Birth Date required")]
        [ValidMatchDate(ErrorMessage = "Birth Date can not be greater than current date")]
        [DataType(DataType.Date), Display(Name = "Enter Birth Date")]
        [ValidBirthDate(ErrorMessage = "Age must be between 15 - 60", MinAge = 15, MaxAge = 60)]
        public DateTime BDate { get; set; }

        public string MatchID { get; set; }
        public List<Players> playersList { get; set; }

    }


}