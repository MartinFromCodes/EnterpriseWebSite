using EnterpriseWebSite.Entities;
using EnterpriseWebSite.Exceptions;
using EnterpriseWebSite.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EnterpriseWebSite.DAL
{
    public class DALNews : DALBase
    {
        public const string Para_Content = "@Content";
        public const string Para_CreateDate = "@CreateDate";
        public const string Para_Id = "@Id";
        public const string Para_ImageUrl = "@ImageUrl";
        public const string Para_IsCommented = "@IsCommented";
        public const string Para_IsDelete = "@IsDelete";
        public const string Para_IsPublic = "@IsPublic";
        public const string Para_IsTop = "@IsTop";
        public const string Para_Original_Id = "@original_Id";
        public const string Para_Title = "@Title";
        public const string Para_UserId = "@UserId";
        public const string Para_ViewTimes = "@ViewTimes";
        private const string SQL_DELETE = "P_DeleteNews";
        private const string SQL_GETALL = "P_GetAllNews";
        private const string SQL_GETITEM = "P_GetItemNews";
        private const string SQL_INSERT = "P_InsertNews";
        private const string SQL_UPDATE = "P_UpdateNews";

        private NewsInfo CreateItem(DataRow dr)
        {
            NewsInfo info = new NewsInfo
            {
                NewId = Convert.ToInt32(dr["NewId"]),
                Title = Convert.ToString(dr["Title"]),
                Content = Convert.ToString(dr["Content"])
            };

            if (dr["UserId"] is DBNull)
            {
                info.UserId = -1;
            }
            else
            {
                info.UserId = Convert.ToInt32(dr["UserId"]);
            }
            if (dr["IsTop"] is DBNull)
            {
                info.IsTop = false;
            }
            else
            {
                info.IsTop = Convert.ToBoolean(dr["IsTop"]);
            }
            if (dr["IsCommented"] is DBNull)
            {
                info.IsCommented = false;
            }
            else
            {
                info.IsCommented = Convert.ToBoolean(dr["IsCommented"]);
            }
            if (dr["IsPublic"] is DBNull)
            {
                info.IsPublic = false;
            }
            else
            {
                info.IsPublic = Convert.ToBoolean(dr["IsPublic"]);
            }
            if (dr["IsDelete"] is DBNull)
            {
                info.IsDelete = false;
            }
            else
            {
                info.IsDelete = Convert.ToBoolean(dr["IsDelete"]);
            }
            if (dr["CreateDate"] is DBNull)
            {
                info.CreateDate = DateTime.MinValue;
            }
            else
            {
                info.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
            }
            if (dr["ViewTimes"] is DBNull)
            {
                info.ViewTimes = 0;
            }
            else
            {
                info.ViewTimes = Convert.ToInt32(dr["ViewTimes"]);
            }
            info.ImageUrl = Convert.ToString(dr["ImageUrl"]);
            return info;
        }

        private NewsInfo CreateItem(SqlDataReader dr)
        {
            NewsInfo info = new NewsInfo
            {
                NewId = Convert.ToInt32(dr["NewId"]),
                Title = Convert.ToString(dr["Title"]),
                Content = Convert.ToString(dr["Content"])
            };
            if (dr["UserId"] is DBNull)
            {
                info.UserId = -1;
            }
            else
            {
                info.UserId = Convert.ToInt32(dr["UserId"]);
            }
            if (dr["IsTop"] is DBNull)
            {
                info.IsTop = false;
            }
            else
            {
                info.IsTop = Convert.ToBoolean(dr["IsTop"]);
            }
            if (dr["IsCommented"] is DBNull)
            {
                info.IsCommented = false;
            }
            else
            {
                info.IsCommented = Convert.ToBoolean(dr["IsCommented"]);
            }
            if (dr["IsPublic"] is DBNull)
            {
                info.IsPublic = false;
            }
            else
            {
                info.IsPublic = Convert.ToBoolean(dr["IsPublic"]);
            }
            if (dr["IsDelete"] is DBNull)
            {
                info.IsDelete = false;
            }
            else
            {
                info.IsDelete = Convert.ToBoolean(dr["IsDelete"]);
            }
            if (dr["CreateDate"] is DBNull)
            {
                info.CreateDate = DateTime.MinValue;
            }
            else
            {
                info.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
            }
            if (dr["ViewTimes"] is DBNull)
            {
                info.ViewTimes = 0;
            }
            else
            {
                info.ViewTimes = Convert.ToInt32(dr["ViewTimes"]);
            }
            info.ImageUrl = Convert.ToString(dr["ImageUrl"]);
            return info;
        }


        public int Delete(int id)
        {
            List<SqlParameter> list = new List<SqlParameter> {
        PrepareParameter("@Id", id)
    };
            int num = 0;
            try
            {
                using (base.Connection)
                {
                    num = SqlHelper.ExecuteNonQuery(base.Connection, CommandType.StoredProcedure, "P_DeleteNews", list.ToArray());
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

        public List<NewsInfo> GetData()
        {
            List<NewsInfo> list = new List<NewsInfo>();
            using (base.Connection)
            {
                using (DataSet set = SqlHelper.ExecuteDataset(base.Connection, CommandType.StoredProcedure, "P_GetAllNews"))
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

        public NewsInfo GetData(int id)
        {
            NewsInfo info = null;
            List<SqlParameter> list = new List<SqlParameter> {
        PrepareParameter("@Id", id)
    };
            using (base.Connection)
            {
                using (DataSet set = SqlHelper.ExecuteDataset(base.Connection, CommandType.StoredProcedure, "P_GetItemNews", list.ToArray()))
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

        public int Insert(NewsInfo item)
        {
            List<SqlParameter> list = new List<SqlParameter> 
            {
                PrepareParameter("@Title", item.Title),
                PrepareParameter("@Content", item.Content),
                PrepareParameter("@UserId", item.UserId),
                PrepareParameter("@IsTop", item.IsTop),
                PrepareParameter("@IsCommented", item.IsCommented),
                PrepareParameter("@IsPublic", item.IsPublic),
                PrepareParameter("@IsDelete", item.IsDelete),
                PrepareParameter("@CreateDate", item.CreateDate),
                PrepareParameter("@ViewTimes", item.ViewTimes),
                PrepareParameter("@ImageUrl", item.ImageUrl)
              };
            int num = 0;
            try
            {
                using (base.Connection)
                {
                    num = Convert.ToInt32(SqlHelper.ExecuteScalar(base.Connection, CommandType.StoredProcedure, "P_InsertNews", list.ToArray()));
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


        public int Update(NewsInfo item, int original_Id)
        {
            List<SqlParameter> list = new List<SqlParameter> {
        PrepareParameter("@original_Id", original_Id),
        PrepareParameter("@Title", item.Title),
        PrepareParameter("@Content", item.Content),
        PrepareParameter("@UserId", item.UserId),
        PrepareParameter("@IsTop", item.IsTop),
        PrepareParameter("@IsCommented", item.IsCommented),
        PrepareParameter("@IsPublic", item.IsPublic),
        PrepareParameter("@IsDelete", item.IsDelete),
        PrepareParameter("@CreateDate", item.CreateDate),
        PrepareParameter("@ViewTimes", item.ViewTimes),
        PrepareParameter("@ImageUrl", item.ImageUrl)
    };
            int num = 0;
            try
            {
                using (base.Connection)
                {
                    num = SqlHelper.ExecuteNonQuery(base.Connection, CommandType.StoredProcedure, "P_UpdateNews", list.ToArray());
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
                case "@original_Id":
                    return new SqlParameter("@original_Id", SqlDbType.Int) { Value = value };

                case "@Id":
                    return new SqlParameter("@Id", SqlDbType.Int) { Value = value };

                case "@Title":
                    return new SqlParameter("@Title", SqlDbType.NVarChar) { Value = value };

                case "@Content":
                    return new SqlParameter("@Content", SqlDbType.NVarChar) { Value = value };

                case "@UserId":
                    return new SqlParameter("@UserId", SqlDbType.Int) { Value = value };

                case "@IsTop":
                    return new SqlParameter("@IsTop", SqlDbType.Bit) { Value = value };

                case "@IsCommented":
                    return new SqlParameter("@IsCommented", SqlDbType.Bit) { Value = value };

                case "@IsPublic":
                    return new SqlParameter("@IsPublic", SqlDbType.Bit) { Value = value };

                case "@IsDelete":
                    return new SqlParameter("@IsDelete", SqlDbType.Bit) { Value = value };

                case "@CreateDate":
                    return new SqlParameter("@CreateDate", SqlDbType.DateTime) { Value = value };

                case "@ViewTimes":
                    return new SqlParameter("@ViewTimes", SqlDbType.Int) { Value = value };

                case "@ImageUrl":
                    return new SqlParameter("@ImageUrl", SqlDbType.NVarChar) { Value = value };
            }
            return null;
        }












    }
}
