using LearnMVC.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace LearnMVC.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(UserDetails u)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
                UserStatus status = empBL.GetUserValidity(u);
                bool IsAdmin = status == UserStatus.AuthenticatedAdmin;

                if (status == UserStatus.NonAuthenticatedUser)
                {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password.");
                    return View("Login");
                }

                    FormsAuthentication.SetAuthCookie(u.UserName, false);
                    Session["IsAdmin"] = IsAdmin;
                    return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}