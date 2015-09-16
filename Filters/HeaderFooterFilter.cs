using LearnMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnMVC.Filters
{
    public class HeaderFooterFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ViewResult v = filterContext.Result as ViewResult;
            if (v != null) // v will be null when not a ViewResult
            {
                BaseViewModel bvm = v.Model as BaseViewModel;
                if (bvm != null) // bvm will be null when we want a view without header and footer
                {
                    bvm.UserName = HttpContext.Current.User.Identity.Name;
                    bvm.FooterData = new FooterViewModel();
                    bvm.FooterData.CompanyName = "Acme Inc.";
                    bvm.FooterData.Year = DateTime.Now.Year.ToString();
                }
            }
        }
    }
}