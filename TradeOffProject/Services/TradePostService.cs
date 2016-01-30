using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradeOffProject.Domain;
using TradeOffProject.Infrastructure;
using TradeOffProject.Services.Models;

namespace TradeOffProject.Services {
    public class TradePostService {

        private TradePostRepository _tradePostRepo;
        private ApplicationUserManager _userRepo;
        private CategoryRepository _catRepo;

        public TradePostService(TradePostRepository tradePostRepo, ApplicationUserManager userRepo, CategoryRepository catRepo) {
            _tradePostRepo = tradePostRepo;
            _userRepo = userRepo;
            _catRepo = catRepo;
        }

        public IList<TradePostDTO> GetTradePosts() {
            return (from t in _tradePostRepo.FindTradePosts()
                    select new TradePostDTO() {
                        Name = t.Name,
                        Description = t.Description,
                        Categories = (from c in t.Categories
                                      select c.Name).ToList(),
                        Picture = new PictureDTO() {
                            Url = t.Picture.Url
                        },
                        Owner = new ApplicationUserDTO() {
                            UserName = t.Owner.UserName
                        },
                        Date = t.Date
                    }).ToList();
        }

        public TradePostDTO AddTradePost(TradePostDTO dto, string username) {

            var user = _userRepo.FindByName(username);

            var tradePost = new TradePost() {
                Name = dto.Name,
                Description = dto.Description,
                Categories = _catRepo.FindCategoriesByName(dto.Categories.ToArray()).ToList(),
                Owner = user
            };

            _tradePostRepo.Add(tradePost);
            _tradePostRepo.SaveChanges();

            return new TradePostDTO() {
                Name = tradePost.Name,
                Description = tradePost.Description,
                //Categories = tradePost.categories,
                Picture = new PictureDTO() {
                    Url = tradePost.Picture?.Url
                },
                Date = tradePost.Date
            };
        }
    }
}