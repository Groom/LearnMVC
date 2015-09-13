using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearnMVC.Validations
{
    public class FirstNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Please provide first name");
            }
            else
            {
                if (value.ToString().Contains("@"))
                {
                    return new ValidationResult("First name should not contain \"@\"");
                }
            }

            return ValidationResult.Success;
        }
    }
}