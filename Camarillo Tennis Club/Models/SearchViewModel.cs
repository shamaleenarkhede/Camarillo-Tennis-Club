using System;
using System.ComponentModel.DataAnnotations;
using Camarillo_Tennis_Club.Validation_Attributes;

namespace Camarillo_Tennis_Club.Models
{
    public class SearchViewModel
    {
      //  [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 3 characters required")]
      //  [Required(ErrorMessage = "Required")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Invalid")]
        [Display(Name = "Enter Event Location or Player Name")]
        public string SearchString { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [ValidMatchDate(ErrorMessage = "Match Date can not be greater than current date")]
        [Display(Name = "Enter Event Date")]
        public DateTime? SearchDate { get; set; }
    }
}