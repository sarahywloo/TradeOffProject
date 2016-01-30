using TradeOffProject.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TradeOffProject.Infrastructure {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) {
        }

        public static ApplicationDbContext Create() {
            return new ApplicationDbContext();
        }

        //IDbSet is the interface to the tables
        public IDbSet<Address> Addresses { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Picture> Pictures { get; set; }
        public IDbSet<TradePost> TradePosts { get; set; }
    }
}