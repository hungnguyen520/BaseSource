using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BaseSource.Factory.DbContexts
{
    public interface IMainDbContext
    {
        DbSet<Entity> Set<Entity>() where Entity : class;

        DbEntityEntry<Entity> Entry<Entity>(Entity entity) where Entity : class;

        int SaveChanges();

        void Dispose();
    }
}