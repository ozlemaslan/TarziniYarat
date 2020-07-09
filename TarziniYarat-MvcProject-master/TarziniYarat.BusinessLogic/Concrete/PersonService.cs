using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.BusinessLogic.Abstract;
using TarziniYarat.BusinessLogic.PersonHelpers;
using TarziniYarat.DataAccess.Abstract;
using TarziniYarat.Model;

namespace TarziniYarat.BusinessLogic.Concrete
{
    public class PersonService : IPersonService, IPersonHelper
    {
        IPersonDAL _personDAL;

        public PersonService(IPersonDAL personDAL)
        {
            _personDAL = personDAL;
        }

        public bool Add(Person entity)
        {
            try
            {
                CheckPassword(entity.Password);
                CheckTCKN(entity.TCKN);
                entity.IsActive = false;
                return _personDAL.Add(entity) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CheckPassword(string password)
        {
            string karakter = "abcdefghijklmnoprstuvyz0123456789";
            for(int i=0;i<karakter.Length;i++)
            {
                if (password.Contains(karakter[i]))
                {
                    if (password.Length < 7)
                    {
                        continue;
                        throw new Exception("Şifre 6 karakterden az olamaz.");
                    }
                    else if (password.Length==7)
                    {
                        throw new Exception("Doğru şifre");
                    }
                    else if (password.Length > 7)
                    {
                        throw new Exception("Şifre 6 karakterden fazla olamaz.");
                    }
                }
                else
                {
                    continue;
                }
            }
          

        }

        public void CheckTCKN(string tckn)
        {
            if (tckn.Length < 11)
            {
                throw new Exception("TC Kimlik numaranız 11 Rakamdan daha küçük olamaz.");
            }
            else if (tckn.Length > 11)
            {
                throw new Exception("TC Kimlik numaranız 11 Rakamdan daha büyük olamaz.");
            }
        }

        public bool Delete(int entityID)
        {
            Person person = _personDAL.Get(a => a.PersonID == entityID);
            return _personDAL.Delete(person) > 0;
        }

        public List<Person> GetAll()
        {
            return _personDAL.GetAll().ToList();
        }

        public Person GetByID(int entityID)
        {
            return _personDAL.Get(a => a.PersonID == entityID);
        }

   

        public bool Update(Person entity)
        {
            return _personDAL.Update(entity) > 0;
        }
    }
}
