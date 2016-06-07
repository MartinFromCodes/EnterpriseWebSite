using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseWebSite.Controllers
{
    public class OthersController : Controller
    {
        //
        // GET: /Others/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Guest()
        {
            return View();
        }
    }
}
