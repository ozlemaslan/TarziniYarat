using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using TarziniYarat.BusinessLogic.Abstract;
using TarziniYarat.Model;
using TarziniYarat.UI.MVC.Filtres;
using TarziniYarat.UI.MVC.Models;

namespace TarziniYarat.UI.MVC.Controllers
{
    
    public class CardController : Controller
    {
        IProductService _productService;
        IPersonDetailsService _personDetailsService;
        IShipperService _shipperService;
        IOrderService _orderService;
        public CardController(IProductService productService, IPersonDetailsService personDetailsService,IShipperService shipperService,IOrderService orderService)
        {
            _productService = productService;
            _personDetailsService = personDetailsService;
            _shipperService = shipperService;
            _orderService = orderService;
        }
        public JsonResult AddToCart(int productID)
        {
            Product p = _productService.GetByID(productID);
            List<CartItem> cartProducts = null;

            if (p != null)
            {
                CartItem cartItem = new CartItem();
                cartItem.Name = p.ProductName;
                cartItem.Price = p.UnitPrice;
                cartItem.ProductID = p.ProductID;
                cartItem.Quantity = 1;

                if (Session["cart"] != null)
                {
                    cartProducts = Session["cart"] as List<CartItem>;
                    CartItem cartItem2 = cartProducts.SingleOrDefault(a => a.ProductID == cartItem.ProductID);
                    if (cartItem2 == null)
                    {
                        cartProducts.Add(cartItem);
                    }
                    else
                    {
                        cartItem2.Quantity++;
                    }
                }
                else
                {
                    cartProducts = new List<CartItem>();
                    cartProducts.Add(cartItem);
                }

                Session["cart"] = cartProducts;

                return Json(cartProducts.Count, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Ürün bulunamadı", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult List()
        {
            if (Session["memberID"]==null)
            {
                return RedirectToAction("Login");
            }
            else {
            return View(); }
        }
        
        public ActionResult GetCart()
        {
           
            GetCardList();
            return PartialView("_CartList"); 
            
        }

        private void GetCardList()
        {
            List<CartItem> cart = Session["cart"] == null ? new List<CartItem>() : Session["cart"] as List<CartItem>;
            ViewBag.CartList = cart;
            GetShipperToDLL();
            TempData["Count"] = cart.Count;
        }

        [HttpPost]
        public ActionResult GetPersonDetail(PersonDetails model)
        {

            PersonDetails person = new PersonDetails();
            person.PersonID = (int)Session["memberID"];
            person.PhoneNumber = model.PhoneNumber;
            person.Address = model.Address;
            person.City = model.City;
            person.Country = model.Country;
            _personDetailsService.Add(person);

            Order order = new Order();
            order.CreatedDate = DateTime.Now;
            order.PersonID =(int) Session["memberID"];
            order.ShipperID = 1;
            _orderService.Add(order);
         
            GetCardList();
            GetShipperToDLL();
            TempData["mesaj"] = "<script>alert('Siparişiniz alınmıştır')</script>";
            return RedirectToAction("ResultOrder");
        }
        public ActionResult ResultOrder()
        {
            return View();
        }

        private void GetShipperToDLL()
        {
            List<Shipper> shippers = new List<Shipper>();
            foreach (Shipper item in _shipperService.GetAll())
            {
                shippers.Add(new Shipper { CompanyName = item.CompanyName, ShipperID = item.ShipperID });
            }
            ViewBag.Shippers = shippers;
        }
        
    }
}