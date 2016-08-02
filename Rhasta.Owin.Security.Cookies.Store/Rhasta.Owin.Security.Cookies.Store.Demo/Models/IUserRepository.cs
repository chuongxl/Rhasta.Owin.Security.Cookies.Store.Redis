using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhasta.Owin.Security.Cookies.Store.Demo.Models
{
    public interface IUserRepository
    {
        bool Verify(string email, string pass);
    }
}
