using System;
using BaseSource.Repository.Repositories;
using BaseSource.Factory.Core;
using BaseSource.Factory.DbContexts;

namespace BaseSource.Repository.Core
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private IDbFactory _dbFactory;
        private IMainDbContext _dbContext;

        //===================================================================================================

        private ProductCatalogRepository _productCatalogRepository;
        private ProductRepository _productRepository;

        ProductCatalogRepository IUnitOfWork.productCatalogRepository => _productCatalogRepository ?? (_productCatalogRepository = new ProductCatalogRepository(_dbContext));
        ProductRepository IUnitOfWork.productRepository => _productRepository ?? (_productRepository = new ProductRepository(_dbContext));

        //===================================================================================================


        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
            this._dbContext = _dbFactory.InitMainDbContext();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        protected override void DisposeCore()
        {
            _dbFactory = null;
            _dbContext = null;

            _productCatalogRepository = null;
            _productRepository = null;

            base.DisposeCore();
        }
    }
}