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
    public class RoleService : IRoleService
    {
        IRoleDAL _roleDAL;

        public RoleService(IRoleDAL roleDAL)
        {
            _roleDAL = roleDAL;
        }

        public bool Add(Role entity)
        {
            return _roleDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Role role = _roleDAL.Get(a => a.RoleID == entityID);
            return _roleDAL.Delete(role) > 0;
        }

        public List<Role> GetAll()
        {
            return _roleDAL.GetAll().ToList();
        }

        public Role GetByID(int entityID)
        {
            return _roleDAL.Get(a => a.RoleID == entityID);
        }

        public Role GetRoleByName(string name)
        {
            return _roleDAL.Get(a => a.RoleName == name);
        }

        public bool Update(Role entity)
        {
            return _roleDAL.Update(entity) > 0;
        }
    }
}
