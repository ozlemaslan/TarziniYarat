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
    public class LikeService : ILikeService
    {
        ILikeDAL _likeDAL;

        public LikeService(ILikeDAL likeDAL)
        {
            _likeDAL = likeDAL;
        }

        public bool Add(Like entity)
        {
            return _likeDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Like like = _likeDAL.Get(a => a.LikeID == entityID);
            return _likeDAL.Delete(like) > 0;
        }

        public List<Like> GetAll()
        {
            return _likeDAL.GetAll().ToList();
        }

        public Like GetByID(int entityID)
        {
            return _likeDAL.Get(a => a.LikeID == entityID);
        }

        public bool Update(Like entity)
        {
            return _likeDAL.Update(entity) > 0;
        }
    }
}
