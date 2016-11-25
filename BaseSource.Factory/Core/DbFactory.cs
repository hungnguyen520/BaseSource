using BaseSource.Factory.DbContexts;

namespace BaseSource.Factory.Core
{
    public class DbFactory : Disposable, IDbFactory
    {

        private MainDbContext _mainDbContext;

        public MainDbContext InitMainDbContext()
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