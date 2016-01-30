using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeOffProject.Services.Models {
    public class TradePostDTO {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public IList<string> Categories { get; set; }

        public PictureDTO Picture { get; set; }

        public ApplicationUserDTO Owner { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}