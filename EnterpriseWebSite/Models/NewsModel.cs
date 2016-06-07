using EnterpriseWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace EnterpriseWebSite.Models
{
    public class NewsModel
    {
        public NewsModel()
        { }

        public NewsModel(NewsInfo info)
        {
            NewId = info.NewId;
            Title=info.Title;
            Message=info.Content;
            CreateDate=info.CreateDate;
            IsPublic=info.IsPublic;
            IsTop=info.IsTop;
            ViewTimes=info.ViewTimes;
            IsCommented=info.IsCommented;
            UserId=info.UserId;

        }


        public int NewId { get; set; }
        
        //数据注解
        [StringLength(50,ErrorMessage="最大长度{0},必须至少包含{1}个字符",MinimumLength=1)]
        [Display(Name="标题")]
        public string Title { get; set; }

        [StringLength(10000,ErrorMessage="最大长度{0},必须至少包含{1}个字符",MinimumLength=10)]
        [Display(Name="内容")]
        public string Message { get; set; }
        public bool IsTop { get; set; }
        public bool IsCommented { get; set; }
        public bool IsPublic { get; set; }

        [Display(Name="发布时间")]
        public DateTime CreateDate { get; set; }
        public int ViewTimes { get; set; }
        public string ImageUrl { get; set; }
        public int UserId { get; set; }
        public bool IsDelete { get; set; }

       

    }

    public class NewsListModel
    {
        List<NewsModel> _NewsList;

        public NewsListModel(List<NewsInfo> newsInfoList)
        {
            _NewsList = new List<NewsModel>();
            foreach (NewsInfo newsinfo in newsInfoList)
            {
                NewsModel newsObject = new NewsModel()
                {
                    NewId = newsinfo.NewId,
                    Title = newsinfo.Title,
                    Message = newsinfo.Content,
                    CreateDate = newsinfo.CreateDate,
                    IsDelete = newsinfo.IsDelete,
                    IsPublic = newsinfo.IsPublic,
                    IsTop = newsinfo.IsTop,
                    ViewTimes = newsinfo.ViewTimes,
                    ImageUrl = newsinfo.ImageUrl,
                    IsCommented = newsinfo.IsCommented,
                    UserId = newsinfo.UserId


                };
                _NewsList.Add(newsObject);
            }
        }

        public List<NewsModel> NewsList
        {
            get { return _NewsList; }
            set { _NewsList = value; }

        }

    }
}