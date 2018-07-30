using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Abstractions;
using System.Data.Entity.Infrastructure;

namespace OnlineShopX.DataAccess
{
    public class BaseRepository<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected OnlineShopDbContext _db = new OnlineShopDbContext();

        public async Task<int> AddItemAsync(TEntity item)
        {
            try
            { 
                var model = _db.Set<TEntity>().Add(item);
                return await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                throw ex.InnerException;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Task<TEntity> GetItemAsync(params object[] id)
        {
            try
            {

                var model = _db.Set<TEntity>().FindAsync(id);
                return model;
            }
            catch (DbUpdateConcurrencyException ex)
            {

                throw ex.InnerException;
            }

        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            try
            {
                var model = await _db.Set<TEntity>().ToListAsync();
                return model;

            }
            catch (DbUpdateConcurrencyException ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<int> DeleteItemAsync(TEntity item)
        {
            try
            {
                var model = _db.Set<TEntity>().Remove(item);
                return await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                throw ex.InnerException;
            }
           
             
        }

        public async Task<int> UpdateItemAsync(TEntity Item)
        {
            try
            {
                _db.Entry<TEntity>(Item).State = EntityState.Modified;
                return await _db.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException ex)
            {

                throw ex.InnerException;
            }
        }

    
    }
}