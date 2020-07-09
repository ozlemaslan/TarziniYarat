using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarziniYarat.BusinessLogic.Abstract
{
    public interface IBaseService<TEntity>
    {
        bool Add(TEntity entity);
        bool Delete(int entityID);
        bool Update(TEntity entity);
        TEntity GetByID(int entityID);
        List<TEntity> GetAll();
    }
}
