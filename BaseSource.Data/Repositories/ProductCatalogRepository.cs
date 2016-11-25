using BaseSource.Model.Models;
using System;
using BaseSource.Factory.DbContexts;
using BaseSource.Repository.Core;

namespace BaseSource.Repository.Repositories
{
    public class ProductCatalogRepository : RepositoryBase<ProductCatalog, Guid>
    {
        public ProductCatalogRepository(MainDbContext dbContext) : base(dbContext)
        {
        }
    }
}