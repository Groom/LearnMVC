using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using LearnMVC.Validations;

namespace LearnMVC.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Enter first name")]
        [FirstNameValidation]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter last name")]
        [StringLength(15, ErrorMessage ="Last name should not be longer than 15 characters.")]
        public string LastName { get; set; }

        [SalaryValidation]
        public int? Salary { get; set; }
    }
}