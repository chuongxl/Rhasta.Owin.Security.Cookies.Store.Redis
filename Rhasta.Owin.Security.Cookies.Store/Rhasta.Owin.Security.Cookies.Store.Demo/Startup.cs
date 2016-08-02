using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using Rhasta.Owin.Security.Cookies.Store.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

[assembly: OwinStartup(typeof(Rhasta.Owin.Security.Cookies.Store.Demo.Startup))]
namespace Rhasta.Owin.Security.Cookies.Store.Demo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            IDataProtector dataProtector = app.CreateDataProtector(typeof(RedisAuthenticationTicket).FullName);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
                SessionStore = new RedisSessionStore(new TicketDataFormat(dataProtector)),
                LoginPath = new PathString("/Auth/LogOn"),
                LogoutPath = new PathString("/Auth/LogOut"),

            });


        }
    }
}