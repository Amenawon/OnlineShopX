using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.Abstractions;

namespace OnlineShop.DataAccess.Repository
{
    public class ProductRepository : BaseRepository<Products>, IProductRepository
    {
        public Products GetProductByCategoryId(int id)
        {
            var model = _db.Set<Products>().Include("Category")
                                           .Where(d => d.ProductId == id)
                                           .FirstOrDefault();
            return model;
        }

        public Products GetProductByOrderDetailId(int id)
        {
            var model = _db.Set<Products>().Include("OrderDetail")
                                            .Where(d => d.ProductId == id)
                                            .FirstOrDefault();
            return model;
        }

        public IEnumerable<Products> GetProductsByCategory()
        {
            var model = _db.Set<Products>().Include("OrderDetail")
                                           .ToList();
                                         
            return model;
        }
    }
}
