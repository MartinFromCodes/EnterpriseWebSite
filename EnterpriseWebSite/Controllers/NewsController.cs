using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RTE;
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
            PrepairEditor("Message", delegate(Editor editor)
            {
                //set editor properties here
            });

            return View();
        }

        //this is a  custom function that create and initialize the editor
        protected Editor PrepairEditor(string propertyName, Action<Editor> oninit)
        {
            Editor editor = new Editor(System.Web.HttpContext.Current, propertyName);

            editor.ClientFolder = "/richtexteditor/";

            editor.AjaxPostbackUrl = Url.Action("EditorAjaxHandler");

            if (oninit != null) oninit(editor);


            //try to handle the upload/ajax requests
            bool isajax = editor.MvcInit();

            if (isajax)
                return editor;

            //load the form data if any
            if (this.Request.HttpMethod == "POST")
            {
                string formdata = this.Request.Form[editor.Name].TrimEnd();
                if (formdata != null)
                {
                    editor.LoadFormData(formdata);

                }

            }

            

            //render the editor to ViewBag.Editor 
            ViewBag.Editor = editor.MvcGetString();

            return editor;
        }



        // 提交表单
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Martin]
        public ActionResult CreateNews(NewsModel news)
        {
            int userId = -1;
            if (Session["UserID"] != null)
            {
                userId = int.Parse(Convert.ToString(Session["UserID"]));
            }


            BLLNews bll = new BLLNews();
            NewsInfo newsObject = new NewsInfo()
            {
                Title = SecurityUtility.RemoveIllegalCharacters(news.Title),
                Content = news.Message,
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsPublic = true,
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

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    return RedirectToAction("Index");
        //}


        [HttpGet]
        [Martin]
        public ActionResult Edit(int id)
        {
            //根据id获取要编辑的新闻
            BLLNews bll = new BLLNews();
            NewsInfo newsInfo = bll.GetData(id); 


            //根据实体对象，来构造模型
            NewsModel newsModel = new NewsModel(newsInfo);

            PrepairEditor("Message", delegate(Editor editor)
            {
                //set editor properties here
            });



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
    }
}
