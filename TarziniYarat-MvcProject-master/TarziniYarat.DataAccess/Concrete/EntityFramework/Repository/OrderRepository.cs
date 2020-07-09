using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.DataAccess.EntityFramework;
using TarziniYarat.DataAccess.Abstract;
using TarziniYarat.Model;

namespace TarziniYarat.DataAccess.Concrete.EntityFramework.Repository
{
    public class OrderRepository : EFRepositoryBase<Order, TarziniYaratDbContext>, IOrderDAL
    {
    }
}
