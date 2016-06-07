using EnterpriseWebSite.BLL;
using EnterpriseWebSite.Entities;
using EnterpriseWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EnterpriseWebSite.Controllers
{
    public class MartinAPIController : ApiController
    {
        // GET api/martinapi
        public IEnumerable<NewsInfo> Get()
        {
          //  return new string[] { "value1", "value2" };
            BLLNews bll = new BLLNews();
            //获取所有新闻
            List<NewsInfo> listNews = bll.GetData();


            return listNews;

        }

        // GET api/martinapi/5
        public NewsInfo Get(int id)
        {
           // return "value";
            BLLNews bll = new BLLNews();
            //获取所有新闻
            NewsInfo newInfo = bll.GetData(id);

            return newInfo;
        }

        // POST api/martinapi
        public void Post([FromBody]string value)
        {
        }

        // PUT api/martinapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/martinapi/5
        public void Delete(int id)
        {
        }
    }
}
