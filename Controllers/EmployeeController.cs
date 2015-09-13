using LearnMVC.Models;
using LearnMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Test
        public string GetString() {
            return "Wassup World?! :D";
        }

        //[Authorize]
        public ActionResult Index()
        {
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach(Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.GetValueOrDefault(0).ToString("C");
                empViewModel.SalaryColor = emp.Salary > 35000 ? "yellow" : "green";

                empViewModels.Add(empViewModel);
            }

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            employeeListViewModel.Employees = empViewModels;
            employeeListViewModel.UserName = "Admin";

            return View("Index", employeeListViewModel);
        }

        public ActionResult AddNew()
        {
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }

        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel createEmployeeViewModel = new CreateEmployeeViewModel();
                        createEmployeeViewModel.FirstName = e.FirstName;
                        createEmployeeViewModel.LastName = e.LastName;

                        if (e.Salary.HasValue)
                        {
                            createEmployeeViewModel.Salary = e.Salary.ToString();
                        }
                        else
                        {
                            createEmployeeViewModel.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }

                        return View("CreateEmployee", createEmployeeViewModel);
                    }
                case "Cancel":
                    return RedirectToAction("Index");
            }

            return new EmptyResult();
        }
    }
}