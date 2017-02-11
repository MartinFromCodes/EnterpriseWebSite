using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnterpriseWebSite.Models
{
    public class EnteDataContext:DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
    }
}