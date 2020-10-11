using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeguimientoApi.Service
{
    public interface IAuthManager
    {
        string Authenticate(string userName, string pass);
    }
}
