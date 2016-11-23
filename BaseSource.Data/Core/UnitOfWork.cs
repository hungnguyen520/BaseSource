using System;
using BaseSource.Factory.Core;
using BaseSource.Factory.DbContexts;
using BaseSource.Repository.Repositories;

namespace BaseSource.Repository.Core
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private IDbFactory _dbFactory;
        private IMainDbContext _dbContext;

        //===================================================================================================

        private ProductCatalogRepository _productCatalogRepository;
        private ProductRepository _productRepository;

        public ProductCatalogRepository ProductCatalogRepository
        {
            get
            {
                return _productCatalogRepository ?? (_productCatalogRepository = new ProductCatalogRepository(_dbContext));
            }
        }

        public ProductRepository ProductRepository
        {
            get
            {
                return _productRepository ?? (_productRepository = new ProductRepository(_dbContext));
            }
        }

        //===================================================================================================

        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
            this._dbContext = _dbFactory.InitMainDbContext();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
            this.DisposeCore();
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