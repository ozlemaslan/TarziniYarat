using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TarziniYarat.UI.MVC.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }

        public DateTime BirthDate { get; set; }

        [MinLength(11)]
        public string TCKN { get; set; }
    }
}