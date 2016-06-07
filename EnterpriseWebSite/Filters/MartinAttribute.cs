using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace EnterpriseWebSite.Filters
{
    public class MartinAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            int userId = -1;
            if (filterContext.HttpContext.Session["UserId"]!=null)
            {
                userId = int.Parse(filterContext.HttpContext.Session["UserId"].ToString());

            }

            //用户未登录，就跳转到登录页面，重新定向到另外一个路由
            if (userId<0)
            {
                filterContext.Result = new RedirectToRouteResult(
                    "Default",
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Account",
                            action = "Login"
                        })
                  );
            
            }
            base.OnActionExecuted(filterContext);

        }
    }
}