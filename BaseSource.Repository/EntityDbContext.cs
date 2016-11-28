using BaseSource.Core.Contexts;
using BaseSource.Model.Models;
using System.Data.Entity;

namespace BaseSource.Repository
{
    public class EntityDbContext : DbContext, IEntityDbContext
    {
        public EntityDbContext()
            : base(BaseSource.Common.Constants.CONNECTION_STRING)
        {
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