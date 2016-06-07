using EnterpriseWebSite.BLL;
using EnterpriseWebSite.Entities;
using EnterpriseWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseWebSite.Controllers
{
    public class JQueryController : Controller
    {
        //
        // GET: /JQuery/

        public ActionResult Index()
        {
            return View();

        }

        public JsonResult AJAXTest(int id)
        {
            BLLNews bll = new BLLNews();
            //获取所有新闻
            NewsInfo newsinfo = bll.GetData(id);
            NewsModel model = new NewsModel(newsinfo);
            JsonResult json = this.Json(model, JsonRequestBehavior.AllowGet); 
            //this.Json(newsinfo);
            return json;
        }

    }
}
