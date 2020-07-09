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
    public class CombineService : ICombineService
    {
        ICombineDAL _combineDAL;

        public CombineService(ICombineDAL combineDAL)
        {
            _combineDAL = combineDAL;
        }

        public bool Add(Combine entity)
        {
            return _combineDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Combine combine = _combineDAL.Get(a => a.CombineID == entityID);
            return _combineDAL.Delete(combine) > 0;
        }

        public List<Combine> GetAll()
        {
            return _combineDAL.GetAll().ToList();
        }

        public Combine GetByID(int entityID)
        {
            return _combineDAL.Get(a => a.CombineID == entityID);
        }

        public bool Update(Combine entity)
        {
            return _combineDAL.Update(entity) > 0;
        }
    }
}
