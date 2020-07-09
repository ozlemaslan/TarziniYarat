using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.BusinessLogic.Abstract;
using TarziniYarat.DataAccess.Abstract;
using TarziniYarat.Model;

namespace TarziniYarat.BusinessLogic.Concrete
{
    public class ProductService : IProductService
    {
        IProductDAL _productDAL;

        public ProductService(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public bool Add(Product entity)
        {
            return _productDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Product product = _productDAL.Get(a => a.ProductID == entityID);
            return _productDAL.Delete(product) > 0;
        }

        public List<Product> GetAll()
        {
            return _productDAL.GetAll().ToList();
        }

        public List<Product> GetAllByBrandId(int brandID)
        {
            return _productDAL.GetAll(a => a.BrandID == brandID).ToList();
        }

        public List<Product> GetAllByCategory(int categoryID)
        {
            return _productDAL.GetAll(a => a.CategoryID == categoryID).ToList();
        }

        public List<Product> GetAllByCategoryName(string categoyName)
        {
            return _productDAL.GetAll(a => a.Category.CategoryName == categoyName).ToList();
        }

        public List<Product> GetAllCatIdBrandId(int catID, int brandID)
        {
            return _productDAL.GetAll(a => a.CategoryID == catID && a.BrandID == brandID).ToList();
        }

        public List<Product> GetAllColorId(int colorID)
        {
            return _productDAL.GetAll(a => (int)a.Color == colorID).ToList();
        }

        public List<Product> GetAllSizeId(int sizeID)
        {
            return _productDAL.GetAll(a => (int)a.BodySize == sizeID).ToList();
        }

        public Product GetByID(int entityID)
        {
            return _productDAL.Get(a => a.ProductID == entityID);
        }

        public bool Update(Product entity)
        {
            return _productDAL.Update(entity) > 0;
        }
    }
}
