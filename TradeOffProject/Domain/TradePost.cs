using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeOffProject.Domain {
    public class TradePost : IDbEntity, IActivatable {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public IList<Category> Categories { get; set; }

        public Picture Picture { get; set; }

        public ApplicationUser Owner { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public bool Active { get; set; } = true;
    }
}