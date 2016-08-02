using System.Web;
using System.Web.Mvc;

namespace Rhasta.Owin.Security.Cookies.Store.Demo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
