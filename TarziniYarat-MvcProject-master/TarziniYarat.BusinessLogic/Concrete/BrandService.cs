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
    public class BrandService : IBrandService
    {
        IBrandDAL _brandDAL;

        public BrandService(IBrandDAL brandDAL)
        {
            _brandDAL = brandDAL;
        }

        public bool Add(Brand entity)
        {
            return _brandDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Brand brand = _brandDAL.Get(a => a.BrandID == entityID);
            return _brandDAL.Delete(brand) > 0;
        }

        public List<Brand> GetAll()
        {
            return _brandDAL.GetAll().ToList();
        }

        public Brand GetByID(int entityID)
        {
            return _brandDAL.Get(a => a.BrandID == entityID);
        }

        public bool Update(Brand entity)
        {
            return _brandDAL.Update(entity) > 0;
        }
    }
}
