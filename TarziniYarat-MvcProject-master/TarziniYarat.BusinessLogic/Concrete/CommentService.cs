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
    public class CommentService : ICommentService
    {
        ICommentDAL _commentDAL;

        public CommentService(ICommentDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }

        public bool Add(Comment entity)
        {
            return _commentDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Comment comment = _commentDAL.Get(a => a.CommentID == entityID);
            return _commentDAL.Delete(comment) > 0;
        }

        public List<Comment> GetAll()
        {
            return _commentDAL.GetAll().ToList();
        }

        public List<Comment> GetAllProductId(int? productID)
        {
            return _commentDAL.GetAll(a => a.ProductID == productID).ToList();
        }

        public Comment GetByID(int entityID)
        {
            return _commentDAL.Get(a => a.CommentID == entityID);
        }

        public bool Update(Comment entity)
        {
            return _commentDAL.Update(entity) > 0;
        }
    }
}
