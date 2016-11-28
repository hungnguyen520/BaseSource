using BaseSource.Core.Contexts;
using BaseSource.Core.Repositories;
using BaseSource.Core.UnitOfWorks;
using BaseSource.Repository.Repositories;

namespace BaseSource.Repository.Core
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private IEntityDbContext _dbContext;

        //===================================================================================================

        private IProductCatalogRepository _productCatalogRepository;
        private IProductRepository _productRepository;

        public IProductCatalogRepository ProductCatalogRepository
        {
            get
            {
                return _productCatalogRepository ?? (_productCatalogRepository = new ProductCatalogRepository(_dbContext));
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository ?? (_productRepository = new ProductRepository(_dbContext));
            }
        }

        //===================================================================================================

        public UnitOfWork(IEntityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
            this.DisposeCore();
        }

        protected override void DisposeCore()
        {
            _dbContext = null;

            _productCatalogRepository = null;
            _productRepository = null;

            base.DisposeCore();
        }
    }
}