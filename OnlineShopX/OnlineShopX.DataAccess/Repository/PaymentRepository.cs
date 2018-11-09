using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Abstractions;
using OnlineShop.DataAccess.Interfaces;

namespace OnlineShop.DataAccess.Repository
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public Payment GetPaymentByOrderId(int id)
        {
            var model = _db.Set<Payment>().Include("Orders")
                                        .Where(d => d.PaymentId == id)
                                        .FirstOrDefault();
            return model;
        }
    }
}
