using BaseSource.Factory.DbContexts;

namespace BaseSource.Factory.Core
{
    public class DbFactory : Disposable, IDbFactory
    {

        private IMainDbContext _mainDbContext;

        public IMainDbContext InitMainDbContext()
        {
            return _mainDbContext ?? (_mainDbContext = new MainDbContext());
        }

        protected override void DisposeCore()
        {
            if (_mainDbContext != null)
                _mainDbContext.Dispose();
        }
    }
}