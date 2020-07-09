using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.Model;

namespace TarziniYarat.Model
{
    public class Order:BaseEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
        public int OrderID { get; set; }
        public int PersonID { get; set; }
        public int ShipperID { get; set; }
        public decimal TotalPrice { get; set; }

        //Navigation prop
        public Shipper Shipper { get; set; }
        public Person Person { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
