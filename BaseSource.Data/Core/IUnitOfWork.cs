using BaseSource.Repository.Repositories;
using System;

namespace BaseSource.Repository.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        ProductCatalogRepository productCatalogRepository { get; }
        ProductRepository productRepository { get; }

    }
}