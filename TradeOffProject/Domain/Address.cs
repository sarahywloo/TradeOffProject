using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeOffProject.Domain {
    public class Address : IDbEntity, IActivatable {

        public int Id { get; set; }

        public string Street { get; set; }

        public string Street2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        public string PostalCode { get; set; }

        //public ApplicationUser Owner { get; set; }

        public bool Active { get; set; } = true;
    }
}