using BaseSource.Identity.Models;
using BaseSource.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BaseSource.Build
{
    public class BuildDbContext : IdentityDbContext<ApplicationUser>
    {
        public BuildDbContext()
            : base(BaseSource.Common.Constants.CONNECTION_STRING, throwIfV1Schema: false)
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

        public static BuildDbContext Create()
        {
            return new BuildDbContext();
        }
    }
}