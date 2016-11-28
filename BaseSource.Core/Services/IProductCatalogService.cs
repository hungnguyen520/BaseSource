using BaseSource.Model.Models;
using System;
using System.Collections.Generic;

namespace BaseSource.Core
{
    public interface IProductCatalogService
    {
        ProductCatalog Add(ProductCatalog productCategory);

        void Edit(ProductCatalog productCategory);

        ProductCatalog Delete(Guid id);

        IEnumerable<ProductCatalog> GetAll();

        ProductCatalog GetById(Guid id);

    }
}