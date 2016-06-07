using EnterpriseWebSite.Entities;
using EnterpriseWebSite.Exceptions;
using EnterpriseWebSite.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EnterpriseWebSite.DAL
{
    public class DALUsers:DALBase
    {
        public const string Para_CreateTime = "@CreateTime";
        public const string Para_EmailAddress = "@EmailAddress";
        public const string Para_LastLoginTime = "@LastLoginTime";
        public const string Para_Original_UserID = "@original_UserID";
        public const string Para_Password = "@Password";
        public const string Para_Status = "@Status";
        public const string Para_UserID = "@UserID";
        public const string Para_UserName = "@UserName";
        private const string SQL_DELETE = "P_DeleteUsers";
        private const string SQL_GETALL = "P_GetAllUsers";
        private const string SQL_GETITEM = "P_GetItemUsers";
        private const string SQL_GETITEMBYUSERNAME = "P_GetItemUsersByUserName";
        private const string SQL_INSERT = "P_InsertUsers";
        private const string SQL_UPDATE = "P_UpdateUsers";

      
        private UsersInfo CreateItem(DataRow dr)
        {
            UsersInfo info = new UsersInfo
            {
                UserID = Convert.ToInt32(dr["UserID"]),
                UserName = Convert.ToString(dr["UserName"]),
                Password = Convert.ToString(dr["Password"])
            };
            if (dr["LastLoginTime"] is DBNull)
            {
                info.LastLoginTime = null;
            }
            else
            {
                info.LastLoginTime = new DateTime?(Convert.ToDateTime(dr["LastLoginTime"]));
            }
            info.EmailAddress = Convert.ToString(dr["EmailAddress"]);
            if (dr["Status"] is DBNull)
            {
                info.Status = null;
            }
            else
            {
                info.Status = new int?(Convert.ToInt32(dr["Status"]));
            }
            if (dr["CreateTime"] is DBNull)
            {
                info.CreateTime = null;
                return info;
            }
            info.CreateTime = new DateTime?(Convert.ToDateTime(dr["CreateTime"]));
            return info;
        }

        private UsersInfo CreateItem(SqlDataReader dr)
        {
            UsersInfo info = new UsersInfo
            {
                UserID = Convert.ToInt32(dr["UserID"]),
                UserName = Convert.ToString(dr["UserName"]),
                Password = Convert.ToString(dr["Password"])
            };
            if (dr["LastLoginTime"] is DBNull)
            {
                info.LastLoginTime = null;
            }
            else
            {
                info.LastLoginTime = new DateTime?(Convert.ToDateTime(dr["LastLoginTime"]));
            }
            info.EmailAddress = Convert.ToString(dr["EmailAddress"]);
            if (dr["Status"] is DBNull)
            {
                info.Status = null;
            }
            else
            {
                info.Status = new int?(Convert.ToInt32(dr["Status"]));
            }
            if (dr["CreateTime"] is DBNull)
            {
                info.CreateTime = null;
                return info;
            }
            info.CreateTime = new DateTime?(Convert.ToDateTime(dr["CreateTime"]));
            return info;
        }

        public int Delete(int userID)
        {
            List<SqlParameter> list = new List<SqlParameter> {
        PrepareParameter("@UserID", userID)
    };
            int num = 0;
            try
            {
                using (base.Connection)
                {
                    num = SqlHelper.ExecuteNonQuery(base.Connection, CommandType.StoredProcedure, "P_DeleteUsers", list.ToArray());
                }
            }
            catch (SqlException exception)
            {
                if (exception.Number == 0x223)
                {
                    throw new ForeignKeyException();
                }
                throw;
            }
            return num;
        }
 
        public List<UsersInfo> GetData()
        {
            List<UsersInfo> list = new List<UsersInfo>();
            using (base.Connection)
            {
                using (DataSet set = SqlHelper.ExecuteDataset(base.Connection, CommandType.StoredProcedure, "P_GetAllUsers"))
                {
                    if ((set != null) && (set.Tables.Count > 0))
                    {
                        foreach (DataRow row in set.Tables[0].Rows)
                        {
                            list.Add(this.CreateItem(row));
                        }
                    }
                    return list;
                }
            }
        }
 
        public UsersInfo GetData(int userID)
        {
            UsersInfo info = null;
            List<SqlParameter> list = new List<SqlParameter> {
        PrepareParameter("@UserID", userID)
    };
            using (base.Connection)
            {
                using (DataSet set = SqlHelper.ExecuteDataset(base.Connection, CommandType.StoredProcedure, "P_GetItemUsers", list.ToArray()))
                {
                    if ((set != null) && (set.Tables.Count > 0))
                    {
                        foreach (DataRow row in set.Tables[0].Rows)
                        {
                            info = this.CreateItem(row);
                        }
                    }
                    return info;
                }
            }
        }
 
        public UsersInfo GetDataByUserName(string userName)
        {
            UsersInfo info = null;
            List<SqlParameter> list = new List<SqlParameter> {
        PrepareParameter("@UserName", userName)
    };
            using (base.Connection)
            {
                using (DataSet set = SqlHelper.ExecuteDataset(base.Connection, CommandType.StoredProcedure, "P_GetItemUsersByUserName", list.ToArray()))
                {
                    if ((set != null) && (set.Tables.Count > 0))
                    {
                        foreach (DataRow row in set.Tables[0].Rows)
                        {
                            info = this.CreateItem(row);
                        }
                    }
                    return info;
                }
            }
        }
 
        public int Insert(UsersInfo item)
        {
            List<SqlParameter> list = new List<SqlParameter> {
        PrepareParameter("@UserName", item.UserName),
        PrepareParameter("@Password", item.Password),
        PrepareParameter("@LastLoginTime", item.LastLoginTime),
        PrepareParameter("@EmailAddress", item.EmailAddress),
        PrepareParameter("@Status", item.Status),
        PrepareParameter("@CreateTime", item.CreateTime)
    };
            int num = 0;
            try
            {
                using (base.Connection)
                {
                    num = Convert.ToInt32(SqlHelper.ExecuteScalar(base.Connection, CommandType.StoredProcedure, "P_InsertUsers", list.ToArray()));
                }
            }
            catch (SqlException exception)
            {
                if (exception.Number == 0xa43)
                {
                    throw new PrimaryKeyException();
                }
                if (exception.Number == 0xa29)
                {
                    throw new UniqueKeyException();
                }
                if (exception.Number == 0x223)
                {
                    throw new ForeignKeyException();
                }
                throw;
            }
            return num;
        }
   
        public static SqlParameter PrepareParameter(string name, object value)
        {
            switch (name)
            {
                case "@original_UserID":
                    return new SqlParameter("@original_UserID", SqlDbType.Int) { Value = value };

                case "@UserID":
                    return new SqlParameter("@UserID", SqlDbType.Int) { Value = value };

                case "@UserName":
                    return new SqlParameter("@UserName", SqlDbType.NVarChar) { Value = value };

                case "@Password":
                    return new SqlParameter("@Password", SqlDbType.NVarChar) { Value = value };

                case "@LastLoginTime":
                    return new SqlParameter("@LastLoginTime", SqlDbType.DateTime) { Value = value };

                case "@EmailAddress":
                    return new SqlParameter("@EmailAddress", SqlDbType.NVarChar) { Value = value };

                case "@Status":
                    return new SqlParameter("@Status", SqlDbType.Int) { Value = value };

                case "@CreateTime":
                    return new SqlParameter("@CreateTime", SqlDbType.DateTime) { Value = value };
            }
            return null;
        }
        
        public int Update(UsersInfo item, int original_UserID)
        {
            List<SqlParameter> list = new List<SqlParameter> {
        PrepareParameter("@original_UserID", original_UserID),
        PrepareParameter("@UserName", item.UserName),
        PrepareParameter("@Password", item.Password),
        PrepareParameter("@LastLoginTime", item.LastLoginTime),
        PrepareParameter("@EmailAddress", item.EmailAddress),
        PrepareParameter("@Status", item.Status),
        PrepareParameter("@CreateTime", item.CreateTime)
    };
            int num = 0;
            try
            {
                using (base.Connection)
                {
                    num = SqlHelper.ExecuteNonQuery(base.Connection, CommandType.StoredProcedure, "P_UpdateUsers", list.ToArray());
                }
            }
            catch (SqlException exception)
            {
                if (exception.Number == 0xa43)
                {
                    throw new PrimaryKeyException();
                }
                if (exception.Number == 0xa29)
                {
                    throw new UniqueKeyException();
                }
                if (exception.Number == 0x223)
                {
                    throw new ForeignKeyException();
                }
                throw;
            }
            return num;
        }

 

 



    }
}
