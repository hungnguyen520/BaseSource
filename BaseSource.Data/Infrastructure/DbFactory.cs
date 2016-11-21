namespace BaseSource.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {

        private IBaseSourceDbContext _dbContext;

        public IBaseSourceDbContext Init()
        {
            return _dbContext ?? (_dbContext = new BaseSourceDbContext());
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}