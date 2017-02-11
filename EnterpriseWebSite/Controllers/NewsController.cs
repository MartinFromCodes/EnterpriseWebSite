using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseWebSite.Models;
using EnterpriseWebSite.BLL;
using EnterpriseWebSite.Entities;
using EnterpriseWebSite.Security;
using EnterpriseWebSite.Filters;


namespace EnterpriseWebSite.Controllers
{

    public class NewsController : Controller
    {
        //
        // GET: /News/


        public ActionResult Index()
        {
            BLLNews bll = new BLLNews();
            //获取所有新闻
            List<NewsInfo> listNews = bll.GetData();

            NewsListModel modelList = new NewsListModel(listNews);
            //判断用户是否登录
            if (Session["UserId"] != null)
            {

                ViewBag.IsLogOn = true;
            }
            else
            {
                ViewBag.IsLogOn = false;
            }

            //模型传递给视图
            return View(modelList.NewsList);
        }

        public ActionResult Demos()
        {
            return View();
        }


        //新闻详细信息
        [OutputCache(Duration=360)]
        public ActionResult Details(int id)
        {
            BLLNews bll = new BLLNews();
            NewsInfo newsinfo = bll.GetData(id);
            NewsModel newsModel = new NewsModel(newsinfo);
            return View(newsModel);
        }

        //创建新闻
        [Martin]
        public ActionResult Create()
        {
            return View();
        }



        // 提交表单
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Martin]
        public ActionResult CreateNews(FormCollection fc)
        {
            int userId = -1;
            if (Session["UserID"] != null)
            {
                userId = int.Parse(Convert.ToString(Session["UserID"]));
            }

            NewsModel news = new NewsModel();
            BLLNews bll = new BLLNews();
            NewsInfo newsObject = new NewsInfo()
            {
                Title = fc["Title"].ToString(),
                Content = fc["Message"].ToString(),
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsPublic = Convert.ToBoolean(fc["IsPublic"]),
                IsTop = false,
                ViewTimes = 0,

                IsCommented = false,
                UserId = userId


            };
            //保存到数据库
            bll.Insert(newsObject);

            //返回到列表
            return RedirectToAction("Index");
        }

         


        [HttpGet]
        [Martin]
        public ActionResult Edit(int id)
        {
            //根据id获取要编辑的新闻
            BLLNews bll = new BLLNews();
            NewsInfo newsInfo = bll.GetData(id);


            //根据实体对象，来构造模型
            NewsModel newsModel = new NewsModel(newsInfo);

            return View(newsModel);

        }


        [HttpPost]
        [Martin]
        public ActionResult Edit(NewsModel news)
        {

            try
            {
                int userId = -1;
                if (Session["UserId"] != null)
                {
                    userId = int.Parse(Session["UserID"].ToString());
                }

                BLLNews bll = new BLLNews();
                NewsInfo newsObjest = new NewsInfo()
                {
                    NewId = news.NewId,
                    Title = news.Title,
                    Content = SecurityUtility.RemoveIllegalCharacters(news.Message),
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    IsTop = false,
                    IsPublic = true,
                    ViewTimes = 0,
                    UserId = userId,
                    ImageUrl = ""

                };
                //编辑信息 之后提交更新
                bll.Update(newsObjest);
                return RedirectToAction("Index", "News");
            }
            catch (Exception)
            {

                return View();
            }

        }

        [Martin]
        public ActionResult Delete(int id)
        {
            //删除新闻
            BLLNews bll = new BLLNews();
            bll.Delete(id);

            //返回新闻列表
            return RedirectToAction("Index", "News");

        }

        public JsonResult CreateComments(int newsId, int parentId, string comment)
        {
            int userId = -1;
            if (Session["UserId"] != null)
            {
                userId = int.Parse(Session["UserID"].ToString());
            }
            string userName = "";
            if (Session["UserName"] != null)
            {
                userName = Session["UserName"].ToString();
            }

            BLLComments bllCom = new BLLComments();


            CommentsInfo commentsInfo = new CommentsInfo
            {
                CommentDate=DateTime.Now,
                Comment=comment,
                ParentCommentID=parentId,
                Ip=Request.UserHostAddress,
                PostID=newsId,
                UserName=userName,
                UserId=userId
            };
            //添加评论
            bllCom.Insert(commentsInfo);

            //查询评论
            var CommentList=bllCom.GetDataByPostID(newsId);

            return Json(new { data = CommentList }, JsonRequestBehavior.DenyGet);
        }

        public JsonResult GetComments(int id)
        {
            BLLComments Bll = new BLLComments();
            var CommList = Bll.GetDataByPostID(id);
            return Json(new { data = CommList }, JsonRequestBehavior.DenyGet);
        }

    }
}
