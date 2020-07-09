using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarziniYarat.Core.Model
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            IsActive = true;
            CreatedDate = DateTime.Now;
        }
        [DisplayName("Aktif Mi")]
        public bool IsActive { get; set; }
        [DisplayName("Tarih")]
        public DateTime CreatedDate { get; set; }
    }
}
