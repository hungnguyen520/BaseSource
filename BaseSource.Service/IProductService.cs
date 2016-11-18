using BaseSource.Model.Models;
using System;
using System.Collections.Generic;

namespace BaseSource.Service
{
    public interface IProductService
    {
        Product Add(Product product);

        void Update(Product product);

        Product Delete(Guid id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetLastest(int top);

        IEnumerable<Product> GetHotProduct(int top);

        IEnumerable<Product> GetListProductByCategoryIdPaging(Guid categoryId, int page, int pageSize, string sort, out int totalRow);

        IEnumerable<Product> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        IEnumerable<string> GetListProductByName(string name);

        Product GetById(Guid id);

        IEnumerable<Product> GetRelativeProducts(Guid productId, int top);

        bool SellProduct(Guid productId, int quantity);

        void Save();
    }
}