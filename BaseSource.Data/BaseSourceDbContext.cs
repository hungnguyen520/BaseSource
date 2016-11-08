using BaseSource.Common;
using BaseSource.Model.Models;
using System.Data.Entity;

namespace BaseSource.Data
{
    public class BaseSourceDbContext : DbContext, IBaseSourceDbContext
    {
        public BaseSourceDbContext() : base(Constants.CONNECTION_STRING)
        {
            Database.SetInitializer<BaseSourceDbContext>(null);
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<ProductCatalog> ProductCatalogs { get; set; }
    }
}