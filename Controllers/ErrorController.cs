using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnMVC.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        //
        // GET: /Error/
        public ActionResult Index()
        {
            Exception e = new Exception("Invalid controller and/or Action name");
            HandleErrorInfo eInfo = new HandleErrorInfo(e, "Unknown", "Unknown");
            return View("Error", eInfo);
        }
	}
}