using BaseSource.Core.Contexts;
using BaseSource.Core.Repositories;
using BaseSource.Model.Models;
using BaseSource.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseSource.Repository.Repositories
{
    public class ProductRepository : RepositoryBase<Product, Guid>, IProductRepository
    {
        public ProductRepository(IEntityDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Product> GetListProductByCategoryIdPaging(Guid categoryId, int page, int pageSize, string sort, int totalRow)
        {
            var query = GetMulti(x => x.IsDeleted == false && x.ProductCatalogId == categoryId);

            switch (sort)
            {
                case "hotflag":
                    query = query.OrderByDescending(x => x.HotFlag);
                    break;

                case "safeoff":
                    query = query.OrderByDescending(x => x.SafeOff.HasValue);
                    break;

                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreateDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Product> Search(string keyword, int page, int pageSize, string sort, int totalRow)
        {
            var query = GetMulti(x => x.IsDeleted == false && x.Name.Contains(keyword));

            switch (sort)
            {
                case "hotflag":
                    query = query.OrderByDescending(x => x.HotFlag);
                    break;

                case "safeoff":
                    query = query.OrderByDescending(x => x.SafeOff.HasValue);
                    break;

                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreateDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Product> GetRelativeProducts(Guid productId, int top)
        {
            var product = GetSingleById(productId);
            return GetMulti(x => x.IsDeleted == false && x.Id != productId && x.ProductCatalogId == product.ProductCatalogId).OrderByDescending(x => x.CreateDate).Take(top);
        }
    }
}