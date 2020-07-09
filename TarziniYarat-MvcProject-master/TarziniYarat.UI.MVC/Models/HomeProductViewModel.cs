using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarziniYarat.UI.MVC.Models
{
    public class HomeProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public byte[] Photo { get; set; }
    }
}