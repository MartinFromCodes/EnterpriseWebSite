using EnterpriseWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseWebSite.Controllers
{
    public class HomeController : Controller
    {
        EnteDataContext enteDb = new EnteDataContext();

        public ActionResult Index()
        {
           
            ViewBag.Message = "Mcv interdiction！";
            Auction auction = new Auction {
                Id=12,
                Name="Clar",
                Age=18
            };
           // MusicDB.Auctions.Add(auction);
           // MusicDB.SaveChanges();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        /// <summary>
        /// 联系方式
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 3600)]
        public ActionResult Contact()
        {
            ViewBag.Message = DateTime.Now.Ticks;

            return View();
        }



        /// <summary>
        /// 公司历史
        /// </summary>
        /// <returns></returns>
        //缓存1个小时3600秒
        [OutputCache(Duration = 3600)]
        public ActionResult Historys()
        {

            return View();
        }

        /// <summary>
        /// 组织架构
        /// </summary>
        /// <returns></returns>
        public ActionResult Organize()
        {
            ViewBag.Message="Hello World .Welcome to ASP.NET MVC!";
            return View();
        }
    }
}
