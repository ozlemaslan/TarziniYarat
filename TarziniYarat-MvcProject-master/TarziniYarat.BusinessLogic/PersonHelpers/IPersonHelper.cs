using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarziniYarat.BusinessLogic.PersonHelpers
{
    interface IPersonHelper
    {
        void CheckTCKN(string tckn);
        void CheckPassword(string password);
    }
}
