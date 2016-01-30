using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using TradeOffProject.Presentation.Models;
using TradeOffProject.Services;
using TradeOffProject.Services.Models;

namespace TradeOffProject.Presentation.Controllers {
    public class TradePostsController : ApiController {

        private TradePostService _tradePostService;

        public TradePostsController(TradePostService tradePostService) {
            _tradePostService = tradePostService;
        }

        [HttpGet]
        public IList<TradePostDTO> Get() {

            return _tradePostService.GetTradePosts();
        }

        /*tradePost.Categories,*/

        [HttpPost]
        [Authorize]
        [Route("api/gallery/addpost")]
        public IHttpActionResult addTradePost(TradePostBindingModel tradePost) {

            if (ModelState.IsValid) {
                return Ok(_tradePostService.AddTradePost(new TradePostDTO() {
                    Name = tradePost.Name,
                    Description = tradePost.Description,
                    Categories = (from c in Regex.Matches(@"#\w+", tradePost.Description).Cast<Match>()
                                  select c.Value).ToList()
                }, User.Identity.Name));
            }
            return BadRequest();
        }
    }
}
