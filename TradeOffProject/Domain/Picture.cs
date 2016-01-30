using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeOffProject.Domain {
    public class Picture : IDbEntity, IActivatable {

        public int Id { get; set; }

        public ApplicationUser Owner { get; set; }

        [Required]
        public string Url { get; set; }

        public bool Active { get; set; } = true;
    }
}