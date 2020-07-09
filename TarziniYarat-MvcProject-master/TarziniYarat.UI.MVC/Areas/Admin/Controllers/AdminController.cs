using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarziniYarat.BusinessLogic.Abstract;
using TarziniYarat.Model;
using TarziniYarat.UI.MVC.Filtres;

namespace TarziniYarat.UI.MVC.Areas.Admin.Controllers
{
    
    public class AdminController : Controller
    {
        IPersonService _personService;

        public AdminController(IPersonService personService)
        {
            _personService = personService;
        }
        // GET: Admin/Admin
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                Session["AdminID"] = id;
            }


            return View();
        }

      
        public ActionResult AdminUpdate()
        {
            int id = (int)Session["memberID"];
            Person admin = _personService.GetByID(id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult AdminUpdate(Person adminYeni)
        {
            try
            {
                Person admin = _personService.GetByID(adminYeni.PersonID);
                admin.Name = adminYeni.Name;
                admin.Surname = adminYeni.Surname;
                admin.Username = adminYeni.Surname;
                admin.Password = adminYeni.Password;
                admin.IsActive = adminYeni.IsActive;
                admin.BirthDate = adminYeni.BirthDate;
                admin.TCKN = adminYeni.TCKN;
                _personService.Update(admin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View();
        }


        public ActionResult BrowseComment()
        {
            return View();
        }
    }
}