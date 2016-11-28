using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BaseSource.Core.Contexts
{
    public interface IEntityDbContext
    {
        DbSet<Entity> Set<Entity>() where Entity : class;

        DbEntityEntry<Entity> Entry<Entity>(Entity entity) where Entity : class;

        int SaveChanges();

        void Dispose();
    }
}