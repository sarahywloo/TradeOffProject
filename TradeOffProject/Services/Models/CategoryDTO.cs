﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeOffProject.Services.Models {
    public class CategoryDTO {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IList<TradePostDTO> TradePosts { get; set; }
    }
}