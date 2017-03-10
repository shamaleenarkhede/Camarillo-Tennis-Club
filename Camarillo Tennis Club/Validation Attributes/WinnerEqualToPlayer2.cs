using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Camarillo_Tennis_Club.Validation_Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class WinnerEqualToPlayer2 : ValidationAttribute
    {
        private const string defaultErrorMessage = "{0} have to be from {1}.";

        private string otherProperty1;

        public WinnerEqualToPlayer2(string otherProperty1) : base(defaultErrorMessage)
            {
            if (string.IsNullOrEmpty(otherProperty1))
            {
                throw new ArgumentNullException("otherProperty");
            }

            this.otherProperty1 = otherProperty1;

        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, otherProperty1);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                PropertyInfo otherProperty1Info = validationContext.ObjectInstance.GetType().GetProperty(otherProperty1);


                if (otherProperty1Info == null)
                {
                    return new ValidationResult(string.Format("Property '{0}' is undefined.", otherProperty1));
                }

                var otherProperty1Value = otherProperty1Info.GetValue(validationContext.ObjectInstance, null);

                if (otherProperty1Value != null && !string.IsNullOrEmpty(otherProperty1Value.ToString()))
                {
                    if (value.Equals(otherProperty1Value))
                    {

                    }
                    else
                    {
                        return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                    }

                }
            }


            return ValidationResult.Success;
        }
    
    }
}