using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.BusinessLogic.Abstract;
using TarziniYarat.DataAccess.Abstract;
using TarziniYarat.Model;

namespace TarziniYarat.BusinessLogic.Concrete
{
    public class OrderService : IOrderService
    {
        IOrderDAL _orderDAL;

        public OrderService(IOrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }

        public bool Add(Order entity)
        {
            return _orderDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Order order = _orderDAL.Get(a => a.OrderID == entityID);
            return _orderDAL.Delete(order) > 0;
        }

        public List<Order> GetAll()
        {
            return _orderDAL.GetAll().ToList();
        }

        public Order GetByID(int entityID)
        {
            return _orderDAL.Get(a => a.OrderID == entityID);
        }

        public bool Update(Order entity)
        {
            return _orderDAL.Update(entity) > 0;
        }
    }
}
