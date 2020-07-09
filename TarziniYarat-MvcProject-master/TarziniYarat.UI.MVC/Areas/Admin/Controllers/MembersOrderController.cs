using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;
using TarziniYarat.BusinessLogic.Abstract;
using TarziniYarat.Model;
using TarziniYarat.UI.MVC.Areas.Admin.ViewModels;
using TarziniYarat.UI.MVC.Filtres;

namespace TarziniYarat.UI.MVC.Areas.Admin.Controllers
{

    public class MembersOrderController : Controller
    {
        IShipperService _shipperService;
        IProductService _productService;
        public MembersOrderController(IShipperService shipperService, IProductService productService)
        {
            _shipperService = shipperService;
            _productService = productService;
        }
        public ActionResult StokTraking()
        {
            return View(_productService.GetAll());
        }

        public ActionResult GetProduct(int id)
        {
            var product = _productService.GetByID(id);
            return View("GetProduct", product);
        }

        public ActionResult UpdateProduct(Product product)
        {
            var p = _productService.GetByID(product.ProductID);
            p.UnitsInStock = product.UnitsInStock;
            return RedirectToAction("StokTraking");
        }
    }
}