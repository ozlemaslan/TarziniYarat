using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarziniYarat.UI.MVC.Models
{
    public class ProductComment
    {
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}