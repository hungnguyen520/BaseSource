using BaseSource.Factory.DbContexts;

namespace BaseSource.Factory.Core
{
    public interface IDbFactory
    {
        MainDbContext InitMainDbContext();
    }
}