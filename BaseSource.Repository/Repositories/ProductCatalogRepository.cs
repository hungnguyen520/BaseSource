using BaseSource.Model.Models;
using System;
using BaseSource.Repository.Core;
using BaseSource.Identity;

namespace BaseSource.Repository.Repositories
{
    public class ProductCatalogRepository : RepositoryBase<ProductCatalog, Guid>
    {
        public ProductCatalogRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}