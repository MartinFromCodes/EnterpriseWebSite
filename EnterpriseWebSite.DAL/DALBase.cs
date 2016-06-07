using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EnterpriseWebSite.DAL
{
    public abstract class DALBase
    {
        // Fields
        private string _connectionStrings = ConfigurationManager.ConnectionStrings["MusicDataContext"].ToString();

        // Methods
        public DALBase()
        { 
        
        }

        // Properties
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(this._connectionStrings);
            }
        }
 


    }
}
