using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeOffProject.Services.Models {
    public class ApplicationUserDTO {

        [Required]
        public string UserName { get; set; }

        public AddressDTO Country { get; set; }

        public PictureDTO ProfilePictureUrl { get; set; }


    }
}