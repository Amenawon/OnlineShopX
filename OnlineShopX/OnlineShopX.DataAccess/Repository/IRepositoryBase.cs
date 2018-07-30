using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Abstractions;

namespace OnlineShopX.DataAccess
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task <int> AddItemAsync(TEntity item);
        Task <TEntity> GetItemAsync(params object[] id);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<int> UpdateItemAsync(TEntity item);
        Task<int> DeleteItemAsync(TEntity item);
        void Dispose();
    }
}