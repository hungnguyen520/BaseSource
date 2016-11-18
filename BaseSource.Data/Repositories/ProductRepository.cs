using BaseSource.Data.Infrastructure;
using BaseSource.Model.Models;
using System;

namespace BaseSource.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product, Guid>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}