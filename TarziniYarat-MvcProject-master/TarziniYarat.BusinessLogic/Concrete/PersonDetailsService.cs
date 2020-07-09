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
    public class PersonDetailsService : IPersonDetailsService
    {
        IPersonDetailsDAL _personDetailsDAL;

        public PersonDetailsService(IPersonDetailsDAL personDetailsDAL)
        {
            _personDetailsDAL = personDetailsDAL;
        }

        public bool Add(PersonDetails entity)
        {
            return _personDetailsDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            PersonDetails personDetails = _personDetailsDAL.Get(a => a.PersonID == entityID);
            return _personDetailsDAL.Delete(personDetails) > 0;
        }

        public List<PersonDetails> GetAll()
        {
            return _personDetailsDAL.GetAll().ToList();
        }

        public PersonDetails GetByID(int entityID)
        {
            return _personDetailsDAL.Get(a => a.PersonID == entityID);
        }

        public bool Update(PersonDetails entity)
        {
            return _personDetailsDAL.Update(entity) > 0;
        }
    }
}
