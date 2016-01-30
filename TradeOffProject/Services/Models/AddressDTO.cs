using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeOffProject.Services.Models {
    public class AddressDTO {

        public int Id { get; set; }

        [Required]
        public string Country { get; set; }

    }
}