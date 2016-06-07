using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnterpriseWebSite.Entities
{
    public class NewsInfo
    {


        // Properties
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int NewId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsCommented { get; set; }
        public bool IsDelete { get; set; }
        public bool IsPublic { get; set; }
        public bool IsTop { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public int ViewTimes { get; set; }

        public NewsInfo()
        { 
        
        }
        //construction Method 
        public NewsInfo(int _NewId, string _Title, string _Content, int _UserId, bool _IsTop, bool _IsCommented, bool _IsPublic, bool _IsDelete, DateTime _CreateDate, int _ViewTimes, string _ImageUrl)
        {
            this.NewId = _NewId;
            this.Title = _Title;
            this.Content = _Content;
            this.UserId = _UserId;
            this.IsTop = _IsTop;
            this.IsCommented = _IsCommented;
            this.IsPublic = _IsPublic;
            this.IsDelete = _IsDelete;
            this.CreateDate = _CreateDate;
            this.ViewTimes = _ViewTimes;
            this.ImageUrl = _ImageUrl;
        }



        

    }
}
