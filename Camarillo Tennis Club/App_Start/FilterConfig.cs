using System.Web;
using System.Web.Mvc;

namespace Camarillo_Tennis_Club
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
