using BaseSource.Common;
using BaseSource.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BaseSource.Data
{
    public class BaseSourceDbContext : IdentityDbContext<ApplicationUser>, IBaseSourceDbContext
    {
        public BaseSourceDbContext() : base(Constants.CONNECTION_STRING)
        {
            Database.SetInitializer<BaseSourceDbContext>(null);
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

        public static BaseSourceDbContext Create()
        {
            return new BaseSourceDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => i.UserId);
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}