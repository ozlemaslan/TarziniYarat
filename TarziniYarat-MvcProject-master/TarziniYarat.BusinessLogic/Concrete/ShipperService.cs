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
    public class ShipperService : IShipperService
    {
        IShipperDAL _shipperDAL;

        public ShipperService(IShipperDAL shipperDAL)
        {
            _shipperDAL = shipperDAL;
        }

        public bool Add(Shipper entity)
        {
            return _shipperDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Shipper shipper = _shipperDAL.Get(a => a.ShipperID == entityID);
            return _shipperDAL.Delete(shipper) > 0;
        }

        public List<Shipper> GetAll()
        {
            return _shipperDAL.GetAll().ToList();
        }

        public Shipper GetByID(int entityID)
        {
            return _shipperDAL.Get(a => a.ShipperID == entityID);
        }

        public bool Update(Shipper entity)
        {
            return _shipperDAL.Update(entity) > 0;
        }
    }
}
