using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.DataAccess.Abstract;
using TarziniYarat.DataAccess.Concrete.EntityFramework.Repository;

namespace TarziniYarat.BusinessLogic
{
    public class NinjectModuleDAL: NinjectModule
    {
        public override void Load()
        {
            this.Bind<IBrandDAL>().To<BrandRepository>();
            this.Bind<ICategoryDAL>().To<CategoryRepository>();
            this.Bind<ICombineDAL>().To<CombineRepository>();
            this.Bind<ICommentDAL>().To<CommentRepository>();
            this.Bind<ILikeDAL>().To<LikeRepository>();
            this.Bind<IOrderDetailsDAL>().To<OrderDetailsRepository>();
            this.Bind<IOrderDAL>().To<OrderRepository>();
            this.Bind<IPersonDetailsDAL>().To<PersonDetailsRepository>();
            this.Bind<IPersonDAL>().To<PersonRepository>();
            this.Bind<IProductDAL>().To<ProductRepository>();
            this.Bind<IRoleDAL>().To<RoleRepository>();
            this.Bind<IShipperDAL>().To<ShipperRepository>();
        }
    }
}
