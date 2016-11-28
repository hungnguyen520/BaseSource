using BaseSource.Core.Contexts;
using BaseSource.Core.Repositories;
using BaseSource.Model.Models;
using BaseSource.Repository.Core;
using System;

namespace BaseSource.Repository.Repositories
{
    public class ProductCatalogRepository : RepositoryBase<ProductCatalog, Guid>, IProductCatalogRepository
    {
        public ProductCatalogRepository(IEntityDbContext dbContext) : base(dbContext)
        {
        }
    }
}