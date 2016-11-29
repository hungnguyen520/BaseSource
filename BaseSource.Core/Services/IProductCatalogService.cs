using BaseSource.Model.Dtos;
using BaseSource.Model.Models;
using System;
using System.Collections.Generic;

namespace BaseSource.Core
{
    public interface IProductCatalogService
    {
        void Add(ProductCatalogDto dto);

        void Edit(ProductCatalogDto dto);

        void Delete(Guid id);

        IEnumerable<ProductCatalog> GetAll();

        ProductCatalogDto GetById(Guid id);

    }
}