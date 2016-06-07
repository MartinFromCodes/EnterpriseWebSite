using EnterpriseWebSite.DAL;
using EnterpriseWebSite.Entities;
using EnterpriseWebSite.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnterpriseWebSite.BLL
{
    public class BLLUsers
    {
        public int Delete(int userID)
        {
            return new DALUsers().Delete(userID);
        }

        public List<UsersInfo> GetData()
        {
            return new DALUsers().GetData();
        }

        public UsersInfo GetData(int userID)
        {
            return new DALUsers().GetData(userID);
        }


        public UsersInfo GetDataByUserName(string userName)
        {
            return new DALUsers().GetDataByUserName(userName);
        }

        public int Insert(UsersInfo item)
        {
            return new DALUsers().Insert(item);
        }

        public int Update(UsersInfo item, int original_UserID)
        {
            return new DALUsers().Update(item, original_UserID);
        }

        public static int ValidateUser(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                string strA = HashUtility.GetSHA256Hash(password);
                UsersInfo userInfo = new BLLUsers().GetDataByUserName(userName);
                if (userInfo == null)
                {
                    return -1;
                }

                if (string.CompareOrdinal(strA, userInfo.Password) == 0)
                {
                   // return dataByUserName.UserID;
                    
                    return userInfo.UserID;
                }
            }
            return -1;
        }

 


 


 


 


 


 

    }
}
