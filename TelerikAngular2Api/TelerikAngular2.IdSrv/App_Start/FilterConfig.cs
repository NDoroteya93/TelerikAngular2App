using System.Web;
using System.Web.Mvc;

namespace TelerikAngular2.IdSrv
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
