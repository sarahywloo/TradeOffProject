using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeOffProject.Services.Models {
    public class PictureDTO {

        public int Id { get; set; }

        public ApplicationUserDTO Owner { get; set; }

        [Required]
        public string Url { get; set; }
    }
}