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
    public class OrderDetailsService : IOrderDetailsService
    {
        IOrderDetailsDAL _orderDetailsDAL;

        public OrderDetailsService(IOrderDetailsDAL orderDetailsDAL)
        {
            _orderDetailsDAL = orderDetailsDAL;
        }

        public bool Add(OrderDetails entity)
        {
            return _orderDetailsDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            OrderDetails orderDetails = _orderDetailsDAL.Get(a => a.OrderID == entityID);
            return _orderDetailsDAL.Delete(orderDetails) > 0;
        }

        public List<OrderDetails> GetAll()
        {
            return _orderDetailsDAL.GetAll().ToList();
        }

        public OrderDetails GetByID(int entityID)
        {
            return _orderDetailsDAL.Get(a => a.OrderID == entityID);
        }

        public bool Update(OrderDetails entity)
        {
            return _orderDetailsDAL.Update(entity) > 0;
        }
    }
}
