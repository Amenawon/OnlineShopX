using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Abstractions;

namespace OnlineShopX.DataAccess.Interfaces
{
   public interface ICustomerRepository
    {
        IEnumerable<Customers> GetAllCustomersAsync();
        Task<Customers> GetCustomerByIdAsync(int customerId);
        Task<int> CreateCustomerAsync(Customers item);
        void UpdateCustomerDetail(Customers item);
        void DeleteCustomer(int customerId);

    }
}
