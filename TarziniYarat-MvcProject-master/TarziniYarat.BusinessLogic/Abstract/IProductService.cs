using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Model;

namespace TarziniYarat.BusinessLogic.Abstract
{
    public interface IProductService:IBaseService<Product>
    {
        List<Product> GetAllByCategory(int categoryID);
        List<Product> GetAllByCategoryName(string categoyName);
        List<Product> GetAllByBrandId(int brandID);
        List<Product> GetAllCatIdBrandId(int catID, int brandID);
        List<Product> GetAllSizeId(int sizeID);
        List<Product> GetAllColorId(int colorID);
    }
}
