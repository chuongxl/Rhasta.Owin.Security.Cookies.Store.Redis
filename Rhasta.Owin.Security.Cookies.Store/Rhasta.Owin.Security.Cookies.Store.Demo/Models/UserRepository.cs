using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhasta.Owin.Security.Cookies.Store.Demo.Models
{
    public class UserRepository : IUserRepository
    {
        private static Dictionary<string, string> UserList = new Dictionary<string, string> {
            {"chuongxl@gmail.com","1234aa" },
            {"haha@gmail.com","1234aa" }

        };
        public bool Verify(string email, string pass)
        {
            return UserList.Any(i => i.Key == email && i.Value == pass);
        }
    }
}