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

        //[Required(ErrorMessage ="Enter first name")]
        [FirstNameValidation]
        public string FirstName { get; set; }

        //[Required(ErrorMessage ="Enter last name")]
        public string LastName { get; set; }

        //[DataType(typeof(int), "Salary must be a whole number", "SalaryDataTypeInt", )]
        public int Salary { get; set; }
    }
}