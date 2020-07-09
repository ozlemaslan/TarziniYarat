using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarziniYarat.UI.MVC.Filtres;

namespace TarziniYarat.UI.MVC.Controllers
{
    public class ModelistController : Controller
    {
       
        public ActionResult ModelistBlog()
        {
            return View();
        }
        [HttpPost]
        [ActionName("ModelistBlog")]
        public ActionResult ModelistBloges()
        {
            string baslik = Request.Form["blog"];
            string message = Request.Form["message"];
            TempData["Baslik"] = baslik;
            TempData["Message"] = message;

            return RedirectToAction("Blog", new { controller = "Sites" });
        }
    }
}