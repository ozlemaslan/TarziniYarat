using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.Model;

namespace TarziniYarat.Model
{
    public class Like:BaseEntity
    {
        public int LikeID { get; set; }
        public int PersonID { get; set; }
        public int CombineID { get; set; }
        public DateTime LikeDate { get; set; }

        //Navigation prop
        public Person Person { get; set; }
        public Combine Combine { get; set; }
    }
}
