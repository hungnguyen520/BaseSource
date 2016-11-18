using BaseSource.Data.Repositories;

namespace BaseSource.Data.Infrastructure
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private IDbFactory _dbFactory;
        private IBaseSourceDbContext _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }

        public IBaseSourceDbContext DbContext
        {
            get { return _dbContext ?? (_dbContext = _dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        //===================================================================================================

        private IProductCatalogRepository _productCatalogRepository;
        private IProductRepository _productRepository;

        IProductCatalogRepository IUnitOfWork.productCatalogRepository => _productCatalogRepository;
        IProductRepository IUnitOfWork.productRepository => _productRepository;

        //===================================================================================================

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