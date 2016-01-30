using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradeOffProject.Infrastructure;
using TradeOffProject.Services.Models;

namespace TradeOffProject.Services {
    public class CategoryService {

        private CategoryRepository _catRepo;

        public CategoryService(CategoryRepository catRepo) {
            _catRepo = catRepo;
        }

        public IList<CategoryDTO> GetCategories() {
            return (from c in _catRepo.FindCategories()
                    select new CategoryDTO() {
                        Name = c.Name
                    }).ToList();
        }
    }
}