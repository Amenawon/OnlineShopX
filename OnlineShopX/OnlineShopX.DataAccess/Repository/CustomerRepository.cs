using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Abstractions;
using OnlineShop.DataAccess.Interfaces;

namespace OnlineShop.DataAccess.Repository
{
    public class CustomerRepository : BaseRepository<Customers>, ICustomerRepository
    {
        public IEnumerable<Customers> GetCustomersByOrders()
        {
            try
            {
                var model = _db.Set<Customers>().Include("Orders")
                                                .ToList();
                return model;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public Customers GetOrderByCustomerId(int customerId)
        {
            try
            {
                var model = _db.Set<Customers>().Include("Orders")
                                                .Where(d => d.CustomerId == customerId)
                                                .FirstOrDefault();
                return model;
            }
            catch (Exception)
            {
                throw new NotImplementedException(); 
            }
            
        }
    }
}
