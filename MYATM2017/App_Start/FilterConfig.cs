using System.Web;
using System.Web.Mvc;
using MYATM2017.Models;

namespace MYATM2017
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyLoggingFilterAttribute());
        }
    }
}
