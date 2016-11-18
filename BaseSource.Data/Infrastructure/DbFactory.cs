namespace BaseSource.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private BaseSourceDbContext dbContext;

        public BaseSourceDbContext Init()
        {
            return dbContext ?? (dbContext = new BaseSourceDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}