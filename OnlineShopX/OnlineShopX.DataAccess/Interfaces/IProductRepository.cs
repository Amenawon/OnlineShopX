using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Abstractions;

namespace OnlineShopX.DataAccess.Interfaces
{
    public interface IProductRepository
    {
        Products GetProductByCategoryId(int id);
        Products GetProductByOrderDetailId(int id);
        IEnumerable<Products> GetProductsByCategory();
    }
}
