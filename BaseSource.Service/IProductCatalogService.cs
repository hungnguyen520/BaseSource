using BaseSource.Model.Models;
using System;
using System.Collections.Generic;

namespace BaseSource.Service
{
    public interface IProductCatalogService
    {
        ProductCatalog Add(ProductCatalog productCategory);

        void Update(ProductCatalog productCategory);

        ProductCatalog Delete(Guid id);

        IEnumerable<ProductCatalog> GetAll();

        ProductCatalog GetById(Guid id);

        void Save();
    }
}