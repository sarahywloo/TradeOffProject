using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TradeOffProject.Services;
using TradeOffProject.Services.Models;

namespace TradeOffProject.Presentation.Controllers
{
    public class CategoriesController : ApiController {

        private CategoryService _catService;

        public CategoriesController(CategoryService catService) {
            _catService = catService;
        }

        [HttpGet]
        public IList<CategoryDTO> Get() {
            return _catService.GetCategories();
        }
    }
}
