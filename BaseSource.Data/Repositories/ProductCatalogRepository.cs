using BaseSource.Data.Infrastructure;
using BaseSource.Model.Models;
using System;

namespace BaseSource.Data.Repositories
{
    public class ProductCatalogRepository : RepositoryBase<ProductCatalog, Guid>, IProductCatalogRepository
    {
        public ProductCatalogRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}