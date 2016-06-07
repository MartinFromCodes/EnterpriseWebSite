using EnterpriseWebSite.DAL;
using EnterpriseWebSite.Entities;
using System;
using System.Collections.Generic;


namespace EnterpriseWebSite.BLL
{
    public class BLLNews
    {
        public BLLNews()
        { 
        
        }

        public int Delete(int id)
        {
            return new DALNews().Delete(id);
        }


        public List<NewsInfo> GetData()
        {
            return new DALNews().GetData();
        }

        public NewsInfo GetData(int id)
        {
            return new DALNews().GetData(id);

        }

        public int Insert(NewsInfo item)
        {
            return new DALNews().Insert(item);

        }
        public int Update(NewsInfo item)
        {
            return new DALNews().Update(item,item.NewId);

        }
    }
}
