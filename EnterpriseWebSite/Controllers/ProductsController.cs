using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseWebSite.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> IndexAsync()
        {
            WebClient web = new WebClient();

            string result = await web.DownloadStringAsync("www.bing.com/");

            return View();
        }

    }
}
