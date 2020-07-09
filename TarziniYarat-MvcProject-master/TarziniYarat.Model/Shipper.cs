using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.Model;

namespace TarziniYarat.Model
{
    public class Shipper:BaseEntity
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }
        public int ShipperID { get; set; }
        [DisplayName("Şirket Adı")]
        public string CompanyName { get; set; }
        [DisplayName("Telefon Numarası")]
        public string Phone { get; set; }

        //Navigation prop
        public ICollection<Order> Orders { get; set; }
    }
}
