using BaseSource.Identity;
using BaseSource.Repository.Repositories;

namespace BaseSource.Repository.Core
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private ApplicationDbContext _dbContext;

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

        public UnitOfWork()
        {
            _dbContext = ApplicationDbContext.Create();
        }

        public void Commit()
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