using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarziniYarat.BusinessLogic.Abstract;
using TarziniYarat.Model;
using TarziniYarat.UI.MVC.Filtres;
using TarziniYarat.UI.MVC.Models;

namespace TarziniYarat.UI.MVC.Areas.Admin.Controllers
{
    public class AdminProcessController : Controller
    {
        IProductService _productService;
        ICategoryService _categoryService;
        IBrandService _brandService;
        IPersonService _personService;
        IShipperService _shipperService;
        public AdminProcessController(IProductService productService, ICategoryService categoryService, IBrandService brandService, IPersonService personService, IShipperService shipperService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
            _personService = personService;
            _shipperService = shipperService;
        }

        //while creating a new product,we need to add product's brand which was created before.
        public ActionResult ProductList()
        {
            return View(_productService.GetAll());
        }

        public ActionResult CreateProduct()
        {
            GetAllCategoriesToDLL();
            GetAllBrandsToDLL();
            GetBodyFromEnumToDLL();
            GetColorFromEnumToDLL();
            Product model = new Product();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product model, HttpPostedFileBase image1)
        {
            try
            {
                if (image1 != null)
                {
                    model.Photo = new byte[image1.ContentLength];
                    image1.InputStream.Read(model.Photo, 0, image1.ContentLength);
                }
                _productService.Add(model);
                ViewBag.IsSuccess = true;
            }
            catch (Exception)
            {

                ViewBag.IsSuccess = false;
            }


            GetAllCategoriesToDLL();
            GetAllBrandsToDLL();
            GetBodyFromEnumToDLL();
            GetColorFromEnumToDLL();
            return View(model);
        }

        public ActionResult UpdateProduct(int id)
        {
            Product currentProduct = null;

            if (id == null)
            {
                ViewBag.Check = false;
            }
            else
            {

                currentProduct = _productService.GetByID(id);
                if (currentProduct != null)
                {
                    GetAllCategoriesToDLL();
                    GetAllBrandsToDLL();
                    GetBodyFromEnumToDLL();
                    GetColorFromEnumToDLL();
                    return View(currentProduct);
                }
                else
                {
                    ViewBag.Check = true;
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product p)
        {
            Product product = _productService.GetByID(p.ProductID);
            product.ProductName = p.ProductName;
            product.ProductTitle = p.ProductTitle;
            product.UnitPrice = p.UnitPrice;
            product.UnitsInStock = p.UnitsInStock;
            product.Description = p.Description;
            product.Color = p.Color;
            product.BodySize = p.BodySize;
            product.CategoryID = p.CategoryID;
            product.BrandID = p.BrandID;

            _productService.Update(product);
            ViewBag.Check = false;
            return RedirectToAction("ProductList");
        }

        [HttpPost]
        public JsonResult ActivateProduct(int productID)
        {
            Product product = _productService.GetByID(productID);
            if (product.IsActive == true)
            {
                product.IsActive = false;
                _productService.Update(product);
            }
            else
            {
                product.IsActive = true;
                _productService.Update(product);
            }
            return Json("ok", JsonRequestBehavior.AllowGet);
        }


        public JsonResult UpdateStok(Product p)
        {
            Product product = _productService.GetByID(p.ProductID);
            product.UnitsInStock = p.UnitsInStock;
            _productService.Update(product);
            return Json("ok", JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetProduct(int id)
        {
            Product product = _productService.GetByID(id);

            return Json(product, JsonRequestBehavior.AllowGet);

        }
        public JsonResult DeletePerson()
        {
            return Json(JsonRequestBehavior.AllowGet);
        }

        public ActionResult PersonList()
        {
            List<Person> personList = _personService.GetAll();

            return View(personList);
        }

        public JsonResult ActivatePerson(int personID)
        {
            Person person = _personService.GetByID(personID);
            if (person.IsActive == true)
            {
                person.IsActive = false;
                _personService.Update(person);
            }
            else
            {
                person.IsActive = true;
                _personService.Update(person);
            }
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public JsonResult PersonUyeChange(int personID)
        {
            Person person = _personService.GetByID(personID);
            if (person.RoleID == 4)
            {
                person.RoleID = 2;
            }
            else
            {
                person.RoleID = 2;
            }
            _personService.Update(person);
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public JsonResult PersonModelistChange(int personID)
        {
            Person person = _personService.GetByID(personID);
            if (person.RoleID == 4)
            {
                person.RoleID = 3;
            }
            else
            {
                person.RoleID = 3;
            }
            _personService.Update(person);
            return Json("ok", JsonRequestBehavior.AllowGet);
        }


        public ActionResult BrandList()
        {
            return View(_brandService.GetAll());
        }

        public ActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBrand(Brand brand)
        {
            _brandService.Add(brand);
            return RedirectToAction("BrandList");
        }

    

        private void GetAllBrandsToDLL()
        {
            List<SelectListItem> brands = new List<SelectListItem>();
            foreach (Brand item in _brandService.GetAll())
            {
                brands.Add(new SelectListItem { Text = item.CompanyName, Value = item.BrandID.ToString() });
            }
            ViewBag.Brands = brands;
        }

        public ActionResult ActiveBrand(int brandID)
        {
            Brand brand = _brandService.GetByID(brandID);
            if (brand.IsActive == true)
            {
                brand.IsActive = false;
            }
            else
            {
                brand.IsActive = true;
            }
            _brandService.Update(brand);

            return Json("ok", JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetBrand(int id)
        {
            var brand = _brandService.GetByID(id);
            return View("GetBrand", brand);
        }

        public ActionResult UpdateBrand(Brand brand)
        {
            var b = _brandService.GetByID(brand.BrandID);
            b.CompanyName = brand.CompanyName;
            _brandService.Update(b);
            return RedirectToAction("BrandList");
        }


        // TODO: Body enumı alınıp ViewBag e aktarıldı.
        private void GetBodyFromEnumToDLL()
        {
            string[] bodyEnums = Enum.GetNames(typeof(Size));
            List<SelectListItem> body = new List<SelectListItem>();
            foreach (string item in bodyEnums)
            {
                body.Add(new SelectListItem { Text = item, Value = item });
            }
            ViewBag.Bodies = body;
        }

        // TODO: Color enumı alınıp ViewBag e aktarıldı.
        private void GetColorFromEnumToDLL()
        {
            string[] colorEnums = Enum.GetNames(typeof(Color));
            List<SelectListItem> color = new List<SelectListItem>();
            foreach (string item in colorEnums)
            {
                color.Add(new SelectListItem { Text = item, Value = item });
            }
            ViewBag.Color = color;
        }

        private void GetAllCategoriesToDLL()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            foreach (Category item in _categoryService.GetAll())
            {
                categories.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryID.ToString() });
            }
            ViewBag.Categories = categories;
        }


        public ActionResult CategoryList()
        {
            List<Category> categoryList = _categoryService.GetAll();

            return View(categoryList);
        }

        public JsonResult ActivateCategory(int categoryID)
        {
            Category category = _categoryService.GetByID(categoryID);
            if (category.IsActive == true)
            {
                category.IsActive = false;
            }
            else
            {
                category.IsActive = true;
            }
            _categoryService.Update(category);

            return Json("ok", JsonRequestBehavior.AllowGet);

        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.CategoryName = model.CategoryName;
                category.Description = model.Description;
                try
                {
                    _categoryService.Add(category);
                    return RedirectToAction("CategoryList");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Girdiğiniz bilgileri kontrol ediniz");
            }
            return View();
        }

 

        public ActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("CategoryList");
        }
        public ActionResult DeleteBrand(int id)
        {
            _brandService.Delete(id);
            return RedirectToAction("BrandList");
        }
        public ActionResult DeleteShipper(int id)
        {
            _shipperService.Delete(id);
            return RedirectToAction("ShipperList");
        }
        public ActionResult DeleteProduct(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("ProductList");
        }

        public ActionResult GetCategory(int id)
        {
            var category = _categoryService.GetByID(id);
            return View("GetCategory", category);
        }

        public ActionResult UpdateCategory(Category c1)
        {
            var kat = _categoryService.GetByID(c1.CategoryID);
            kat.CategoryName = c1.CategoryName;
            kat.Description = c1.Description;
            _categoryService.Update(kat);
            return RedirectToAction("CategoryList");
        }


        public ActionResult AddShipper()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddShipper(Shipper model)
        {
            if (ModelState.IsValid)
            {
                Shipper shipper = new Shipper();
                shipper.CompanyName = model.CompanyName;
                shipper.Phone = model.Phone;
                try
                {
                    _shipperService.Add(shipper);
                    return RedirectToAction("shipperList");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Girdiğiniz bilgileri kontrol ediniz");
            }
            return View();
        }

        public ActionResult ShipperList()
        {
            return View(_shipperService.GetAll());
        }

      
        public ActionResult ActiveShipper(int shipperID)
        {
            Shipper shipper = _shipperService.GetByID(shipperID);
            if (shipper.IsActive == true)
            {
                shipper.IsActive = false;
            }
            else
            {
                shipper.IsActive = true;
            }
            _shipperService.Update(shipper);

            return Json("ok", JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetShipper(int id)
        {
            var shipper = _shipperService.GetByID(id);
            return View("GetShipper", shipper);
        }

        public ActionResult UpdateShipper(Shipper yeni)
        {
            var ship = _shipperService.GetByID(yeni.ShipperID);
            ship.CompanyName = yeni.CompanyName;
            ship.Phone = yeni.Phone;
            _shipperService.Update(ship);
            return RedirectToAction("ShipperList");
        }


    }
}