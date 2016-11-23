using BaseSource.Model.Models;
using System;
using System.Collections.Generic;

namespace BaseSource.Service
{
    public interface IProductManagementService
    {

        ProductCatalog AddProductCatalog(ProductCatalog productCategory);

        void UpdateProductCatalog(ProductCatalog productCategory);

        ProductCatalog DeleteProductCatalog(Guid id);

        IEnumerable<ProductCatalog> GetAllProductCatalog();

        ProductCatalog GetByIdProductCatalog(Guid id);

        //===========================================================================

        Product AddProduct(Product product);

        void UpdateProduct(Product product);

        Product DeleteProduct(Guid id);

        IEnumerable<Product> GetAllProduct();

        IEnumerable<Product> GetLastestProduct(int top);

        IEnumerable<Product> GetHotProduct(int top);

        IEnumerable<Product> GetListProductByCategoryIdPaging(Guid categoryId, int page, int pageSize, string sort, int totalRow);

        IEnumerable<Product> SearchProduct(string keyword, int page, int pageSize, string sort, int totalRow);

        IEnumerable<string> GetListProductByName(string name);

        Product GetByIdProduct(Guid id);

        IEnumerable<Product> GetRelativeProducts(Guid productId, int top);

        bool SellProduct(Guid productId, int quantity);

        void Save();
    }
}