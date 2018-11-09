using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Abstractions;

namespace OnlineShop.DataAccess.Interfaces
{
    public interface IOrderRepository
    {
      Orders GetCustomerByOrderId(int id);
    }
}
