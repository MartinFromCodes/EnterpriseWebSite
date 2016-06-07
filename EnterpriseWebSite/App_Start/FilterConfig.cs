using System.Web;
using System.Web.Mvc;

namespace EnterpriseWebSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //在过滤器中增加 httpsAttribute
            //filters.Add(new RequireHttpsAttribute());
        }

        
    }
}