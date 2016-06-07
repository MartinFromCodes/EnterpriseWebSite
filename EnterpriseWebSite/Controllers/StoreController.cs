using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseWebSite.Models;

namespace EnterpriseWebSite.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        public string Index()
        {
            return "Hello from Store.Index() !";
        }

        public string Brows(string genre)
        {
            string message = HttpUtility.HtmlEncode("Store.Brow : genre=" + genre);

            return message;
        }

        

        public string Details()
        {

            return "from Store.Details()";
        }

       

    }
}
