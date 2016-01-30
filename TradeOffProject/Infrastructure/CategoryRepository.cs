using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TradeOffProject.Domain;

namespace TradeOffProject.Infrastructure {
    public class CategoryRepository : GenericRepository<Category> {

        public CategoryRepository(DbContext db) : base(db) { }

        public IQueryable<Category> FindCategories() {
            return from c in Table
                   where c.Active
                   select c;
        }

        public IQueryable<Category> FindCategoriesByName(params string[] names) {
            return from c in Table
                   where names.Contains(c.Name)
                   select c;
        }
    }
}