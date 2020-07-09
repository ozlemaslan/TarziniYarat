using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarziniYarat.Model;

namespace TarziniYarat.UI.MVC.Filtres
{
    public class CustomAuthorize: AuthorizeAttribute
    {
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["person"]==null)
            {
                return false;
            }

            Person currentPerson = httpContext.Session["person"] as Person;
            if (this.Roles.Contains(currentPerson.Role.RoleName))
            {
                return true;
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["person"]==null)
            {
                filterContext.Result = new RedirectResult("/Sites/Login");
            }
            else
            {
                filterContext.Result = new RedirectResult("/Sites/HomePage");
            }
        }
    }
}