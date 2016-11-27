using BaseSource.Identity.Models;
using BaseSource.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BaseSource.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
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

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}