using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Camarillo_Tennis_Club.Validation_Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidMatchDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime _MatchDate = Convert.ToDateTime(value);
                if (_MatchDate > DateTime.Now)
                {
                    return new ValidationResult("Match date can not be greater than current date.");
                }
            }
            return ValidationResult.Success;
        }
    }
}