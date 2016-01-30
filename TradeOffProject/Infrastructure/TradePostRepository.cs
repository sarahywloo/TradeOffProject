using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TradeOffProject.Domain;

namespace TradeOffProject.Infrastructure {
    public class TradePostRepository : GenericRepository<TradePost> {

        public TradePostRepository(DbContext db) : base(db) { }

        public IQueryable<TradePost> FindTradePosts() {
            return from t in Table
                   where t.Active
                   orderby t.Date descending
                   select t;
        }
    }
}