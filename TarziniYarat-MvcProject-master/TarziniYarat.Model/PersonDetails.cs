using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.Model;

namespace TarziniYarat.Model
{
    public class PersonDetails:BaseEntity
    {
        public int PersonDetailsID { get; set; }
        public int PersonID { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        [DisplayName("Ülke")]
        public string Country { get; set; }

        [DisplayName("Şehir")]
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string City { get; set; }

        [DisplayName("Adres")]
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string Address { get; set; }

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        [MinLength(11)]
        public string PhoneNumber { get; set; }

        //Navigation prop
        public Person Person { get; set; }
    }
}
