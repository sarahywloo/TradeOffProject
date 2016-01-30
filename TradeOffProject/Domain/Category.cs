using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeOffProject.Domain {
    public class Category : IDbEntity, IActivatable {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IList<TradePost> TradePosts { get; set; }

        public bool Active { get; set; } = true;
    }
}