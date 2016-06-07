using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnterpriseWebSite.Models
{
    public class MusicDataContext:DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
    }
}