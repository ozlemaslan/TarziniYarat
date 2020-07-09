using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.Model;
using System.Web;
using System.ComponentModel;

namespace TarziniYarat.Model
{
    public class Product:BaseEntity
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetails>();
            Comments = new HashSet<Comment>();
        }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        [DisplayName("Ürün Adı")]
        public string ProductName { get; set; }
        [DisplayName("Resim")]
        public byte[] Photo { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Fiyat")]
        public decimal UnitPrice { get; set; }
        [DisplayName("Stok")]
        public int UnitsInStock { get; set; }
        [DisplayName("Ürün Başlığı")]
        public string ProductTitle { get; set; }
        [DisplayName("Beden")]
        public Size BodySize { get; set; }
        [DisplayName("Renk")]
        public Color Color { get; set; }



        //Navigation prop
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }

    public enum Color
    {
        Kırmızı=1,
        Sarı=2,
        Siyah=3,
        Kahverengi=4,
        Mavi=5,
        Mor=6,
        Yeşil=7,
        Turuncu=8
    }

    public enum Size
    {
        XS=1,
        S=2,
        M=3,
        L=4,
        XL=5,
        XXL=6
    }
}
