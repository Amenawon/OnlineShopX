using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopX.DataAccess;
using OnlineShop.Abstractions;
using OnlineShopX.DataAccess.Interfaces;

namespace OnlineShopX.DataAccess.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public Task<List<Category>> GetProductsByCategories(string categoryName)
        {
            try
            {
                var model = _db.Set<Category>().Include("Products")
                                                .Where(x => x.CategoryName == categoryName)
                                                .ToList();
                return Task.FromResult(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
