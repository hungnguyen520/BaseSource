using BaseSource.Core.Repositories;
using System;

namespace BaseSource.Core.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        IProductCatalogRepository ProductCatalogRepository { get; }

        IProductRepository ProductRepository { get; }
    }
}