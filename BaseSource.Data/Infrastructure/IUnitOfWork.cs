using BaseSource.Data.Repositories;
using System;

namespace BaseSource.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        IProductCatalogRepository productCatalogRepository { get; }
        IProductRepository productRepository { get; }
    }
}