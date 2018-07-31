using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Abstractions;
using OnlineShopX.DataAccess.Interfaces;

namespace OnlineShopX.DataAccess.Repository
{
    public class OrderRepository : BaseRepository<Orders>, IOrderRepository
    {
        public Orders GetCustomerByOrderId(int id)
        {
            var model = _db.Set<Orders>().Include("Customers")
                                        .Where(d => d.OrderId == id)
                                        .FirstOrDefault();
            return model;
        }
    }
}
