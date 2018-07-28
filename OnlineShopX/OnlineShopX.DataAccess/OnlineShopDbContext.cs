using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Abstractions;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OnlineShopX.DataAccess
{
    public class OnlineShopDbContext :DbContext
    {
        public OnlineShopDbContext() : base("OnlineShopDbContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Orders> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Customers> Customer { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
