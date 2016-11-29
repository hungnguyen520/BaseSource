using BaseSource.Model.Models;
using System;
using System.Collections.Generic;

namespace BaseSource.Core
{
    public interface IProductService
    {
        void Add(Product product);

        void Edit(Product product);

        void Delete(Guid id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetLastest(int top);

        IEnumerable<Product> GetHot(int top);

        IEnumerable<Product> GetListByCategoryIdPaging(Guid categoryId, int page, int pageSize, string sort, int totalRow);

        IEnumerable<Product> Search(string keyword, int page, int pageSize, string sort, int totalRow);

        IEnumerable<string> GetListByName(string name);

        Product GetById(Guid id);

        IEnumerable<Product> GetRelative(Guid productId, int top);

    }
}