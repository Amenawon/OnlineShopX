using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Abstractions;
using OnlineShopX.DataAccess.Interfaces;

namespace OnlineShopX.DataAccess.Repository
{
    public class CustomerRepository : BaseRepository<Customers>, ICustomerRepository
    {
        public Task<int> CreateCustomerAsync(Customers item)
        {
            var model =   _db.Customer.Add(item);
            return   _db.SaveChangesAsync();
        }

        public  void DeleteCustomer(int customerId)
        {
            try
            {
                var model = _db.Set<Customers>().Find(customerId);
                _db.Set<Customers>().Remove(model);

                _db.SaveChangesAsync();

                
            }
            catch (NotImplementedException ex)
            {
                 
            }
        }

        public IEnumerable<Customers> GetAllCustomersAsync()
        {
            try
            {
                var model = _db.Set<Customers>().Include("Orders").ToList();
                return model;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Customers> GetCustomerByIdAsync(int customerId)
        {
            try
            {
                var model = _db.Set<Customers>()
                               .Include("Orders")
                               .Where(d => d.CustomerId == customerId)
                               .FirstOrDefault();

                return Task.FromResult(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateCustomerDetail(Customers detail)
        {
            _db.Entry(detail).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            
        }

    }
}
