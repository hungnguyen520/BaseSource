using BaseSource.Data.Infrastructure;
using BaseSource.Model.Models;
using System;
using System.Collections.Generic;

namespace BaseSource.Data.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product, Guid>
    {
        IEnumerable<Product> GetListProductByCategoryIdPaging(Guid categoryId, int page, int pageSize, string sort, int totalRow);

        IEnumerable<Product> Search(string keyword, int page, int pageSize, string sort, int totalRow);

        IEnumerable<Product> GetRelativeProducts(Guid productId, int top);

        bool SellProduct(Guid productId, int quantity);
    }
}