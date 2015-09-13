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
    public class SalaryValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Please provide salary");
            }
            else
            {
                int salary = 0;
                if(int.TryParse(value.ToString(), out salary))
                {
                    if(salary < 12000 || salary > 60000)
                    {
                        return new ValidationResult("Salary must be between 12.000 and 60.000");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}