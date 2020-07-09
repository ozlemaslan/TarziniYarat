using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.Model;

namespace TarziniYarat.Model
{
    public class Comment:BaseEntity
    {
        public int CommentID { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public int? ProductID { get; set; }
        public int? CombineID { get; set; }
        public int PersonID { get; set; }

        //Navigation prop
        public Product Product { get; set; }
        public Combine Combine { get; set; }
    }
}
