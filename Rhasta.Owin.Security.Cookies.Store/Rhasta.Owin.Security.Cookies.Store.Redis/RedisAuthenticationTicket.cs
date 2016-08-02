using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhasta.Owin.Security.Cookies.Store.Redis
{
    public class RedisAuthenticationTicket
    {
        public string Key { get; set; }
        public string TicketValue { get; set; }
    }
}
