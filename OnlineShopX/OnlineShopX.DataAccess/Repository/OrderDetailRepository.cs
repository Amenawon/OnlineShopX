using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Abstractions;
using OnlineShop.DataAccess.Interfaces;

namespace OnlineShop.DataAccess.Repository
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetOrderDetailsByOrders()
        {
            var model = _db.Set<OrderDetail>().Include("Orders")
                                              .ToList();
            return model;
        }

        public OrderDetail GetOrderDetailByOrderId(int id)
        {
            var model = _db.Set<OrderDetail>().Include("Orders")
                                              .Where(d => d.OrderDetailId == id)
                                              .FirstOrDefault();
            return model;
        }

        public OrderDetail GetOrderDetailByProductId(int id)
        {
            var model = _db.Set<OrderDetail>().Include("Products")
                                           .Where(d => d.OrderDetailId == id)
                                           .FirstOrDefault();
            return model;
        }
    }
}
