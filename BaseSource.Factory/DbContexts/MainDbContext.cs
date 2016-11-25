using BaseSource.Common;
using BaseSource.Model.Models;
using System.Data.Entity;

namespace BaseSource.Factory.DbContexts
{
    public class MainDbContext : DbContext
    {
        public MainDbContext() : base(Constants.CONNECTION_STRING)
        {
            Database.SetInitializer<MainDbContext>(null);
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<ProductCatalog> ProductCatalogs { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}