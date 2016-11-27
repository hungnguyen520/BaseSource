using BaseSource.Repository.Repositories;
using System;

namespace BaseSource.Repository.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        ProductCatalogRepository ProductCatalogRepository { get; }
        ProductRepository ProductRepository { get; }

    }
}