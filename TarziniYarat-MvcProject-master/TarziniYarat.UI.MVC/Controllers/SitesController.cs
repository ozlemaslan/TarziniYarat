using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TarziniYarat.BusinessLogic.Abstract;
using TarziniYarat.Model;
using TarziniYarat.UI.MVC.Models;
//using TarziniYarat.UI.MVC.Views;

namespace TarziniYarat.UI.MVC.Controllers
{
    public class SitesController : Controller
    {
        
        IPersonService _personService;
        IRoleService _roleService;
        IProductService _productService;
        ICategoryService _categoryService;
        IBrandService _brandService;
        ICommentService _commentService;
        public SitesController(IPersonService personService, IRoleService roleService, IProductService productService, ICategoryService categoryService, IBrandService brandService, ICommentService commentService)
        {
            _personService = personService;
            _roleService = roleService;
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
            _commentService = commentService;
        }

        public ActionResult HomePage()
        {
            return View(_productService.GetAll());
        }
        public ActionResult Home(int? personID, Product model)
        {
            List<Product> models = new List<Product>();
            foreach (Product item in _productService.GetAll())
            {
                models.Add(new Product()
                {
                    Photo = item.Photo,
                    UnitPrice = item.UnitPrice,
                    ProductName = item.ProductName
                });
            }
            ViewBag.Product = models;
            return RedirectToAction("HomePage", "Sites", new { id = personID });
        }


        public ActionResult Shop(int catID = 0, int brandID = 0, int sizeID = 0, int colorID = 0)
        {
            List<Category> category = _categoryService.GetAll();
            List<Brand> brands = _brandService.GetAll();
            Size[] sizes = (Size[])Enum.GetValues(typeof(Size));
            Color[] colors = (Color[])Enum.GetValues(typeof(Color));
            ViewBag.Color = colors;
            ViewBag.Size = sizes;
            ViewBag.Brand = brands;
            ViewBag.Category = category;
            if (catID != 0)
            {
                return View(_productService.GetAllByCategory(catID));
            }
            else if (brandID != 0)
            {
                return View(_productService.GetAllByBrandId(brandID));
            }
            else if (brandID != 0 && catID != 0)
            {
                return View(_productService.GetAllCatIdBrandId(catID, brandID));
            }
            if (sizeID != 0)
            {
                return View(_productService.GetAllSizeId(sizeID));
            }
            else if (colorID != 0)
            {
                return View(_productService.GetAllColorId(colorID));
            }

            return View(_productService.GetAll());
        }


        public ActionResult ProductDetail(int id)
        {
            GetAllComment(id);
            ViewBag.PersonID = Session["memberID"];
            return View(_productService.GetByID(id));
        }

        private void GetAllComment(int id)
        {
            List<ProductComment> commentProduct = new List<ProductComment>();
            List<Comment> comments = _commentService.GetAllProductId(id);
            foreach (var item in comments)
            {
                ProductComment productComment = new ProductComment()
                {
                    Content = item.Content,
                    CreatedDate = item.CreatedDate,
                    UserName = _personService.GetByID(item.PersonID).Username
                };
                commentProduct.Add(productComment);

            }

            ViewBag.Comment = commentProduct;
        }


        [HttpPost]
        public ActionResult ProductDetail(string message,int productID)
        {
            if (ModelState.IsValid)
            {
                Comment comment = new Comment();
                comment.CommentDate = DateTime.Now;
                comment.Content = message;
                comment.PersonID = (int)Session["memberID"];
                comment.ProductID = productID;
                try
                {
                    _commentService.Add(comment);
                    GetAllComment(productID);
                    return View(_productService.GetByID(productID));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                ViewBag.Hata = "Yorum yapılırken bir hata oluştu. ";

            }
            return View(_productService.GetByID(productID));
        }

        public ActionResult Profil( ) //kullanıcı profil sayfası yapıldı.
        {   
            return View(_personService.GetByID((int)Session["memberID"]));
        }

        [HttpPost]
        public ActionResult Profil(Person p)
        {
            Person person = _personService.GetByID((int)Session["memberID"]);
            person.TCKN = p.TCKN;
            person.Name = p.Name;
            person.Surname = p.Surname;
            person.Username = p.Username;
            person.Password = p.Password;
            _personService.Update(person);
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
      
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult BlogDetail()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (Request.Cookies["login"] != null)
            {
                HttpCookie login = Request.Cookies["login"];
                LoginViewModel user = new LoginViewModel();
                user.UserName = login["mail"];
                user.Password = login["sifre"];

                return View(user);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (login.RememberMe)
            {
                HttpCookie loginCookie = new HttpCookie("login");
                loginCookie.Values.Add("mail", login.UserName);
                loginCookie.Values.Add("sifre", login.Password);
                loginCookie.Expires = DateTime.Now.AddDays(15);

                Response.Cookies.Add(loginCookie);
            }

            List<Person> persons = _personService.GetAll();
            foreach (var item in persons)
            {
                if (login.UserName == item.Username && login.Password == item.Password)
                {
                    Session["person"] = _personService.GetByID(item.PersonID);
                    Session["memberID"] = item.PersonID;                 
                    if (login.UserName== "thelastdance@mail.com" && login.Password=="123456")
                    {
                        return RedirectToAction("Index", "Admin", new { area = "Admin", id = item.PersonID });
                    }
                    else if (item.RoleID==2 && item.IsActive==true)
                    {
                        return RedirectToAction("HomePage", "Sites", new { id = item.PersonID });
                    }
                    else if (item.RoleID==3 && item.IsActive==true)
                    {
                        return RedirectToAction("Home", "Sites", new  { Username = item.Username, PersonID = item.PersonID });
                    }
                }
                else
                {
                    continue;
                }
            }
            ViewBag.Hata = "Kullanıcı Bilgilerinizi Kontrol Ediniz.";
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person();
                person.Name = model.Name;
                person.Surname = model.Surname;
                person.Username = model.UserName;
                person.Password = model.Password;
                person.BirthDate = model.BirthDate;
                person.TCKN = model.TCKN;
                person.RoleID = 4;
                try
                {
                    _personService.Add(person);
                    return RedirectToAction("WaitPage");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                ViewBag.Hata = "Bilgilerinizi kontrol ediniz. " +
                    "Şifreniz en az 6 karakterli olmalı. En az 1 sayı ve 1 harf içermelidir. " +
                    "Kimlik numaranız 11 rakamdan az olamaz.";
                //ModelState.AddModelError("", "Girdiğiniz bilgileri kontrol ediniz");
            }
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult WaitPage()
        {
            return View();
        }
    }
}