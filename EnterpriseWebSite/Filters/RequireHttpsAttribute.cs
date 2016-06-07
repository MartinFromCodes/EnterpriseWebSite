using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseWebSite.Filters
{
    public class RequireHttpsAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext fileContext)
        {
            //如果已经是https连接则不处理，否则重定向到https连接
            if (!fileContext.HttpContext.Request.IsSecureConnection)
            {
                //获取当前请求的Path
                string path = fileContext.HttpContext.Request.Path;

                //从web.config中获取到host，也可以直接从httpContext中获取
                string host = System.Configuration.ConfigurationManager.AppSettings["HostName"];

                //从web.config中获取到port 
                string port = System.Configuration.ConfigurationManager.AppSettings["httpsPort"];


                //如果端口号为空表示使用默认端口，否则将host写错host:port的形式
                if (port!=null)
                {
                    host = string.Format("{0}:{1}", host, port);

                }

                //重定向到https连接
                fileContext.HttpContext.Response.Redirect(string.Format("https://{0}:{1}",host,port));



            }
            
        }

    }
}