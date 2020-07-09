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
    public class CategoryService : ICategoryService
    {
        ICategoryDAL _categoryDAL;

        public CategoryService(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public bool Add(Category entity)
        {
            return _categoryDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Category category = _categoryDAL.Get(a => a.CategoryID == entityID);
            return _categoryDAL.Delete(category) > 0;
        }

        public List<Category> GetAll()
        {
            return _categoryDAL.GetAll().ToList();
        }

        public Category GetByID(int entityID)
        {
            return _categoryDAL.Get(a => a.CategoryID == entityID);
        }

        public bool Update(Category entity)
        {
            return _categoryDAL.Update(entity) > 0;
        }
    }
}
