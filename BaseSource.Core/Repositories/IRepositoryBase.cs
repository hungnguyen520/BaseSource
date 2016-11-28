using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BaseSource.Core.Repositories
{
    public interface IRepositoryBase<TEntity, TKey> where TEntity : class
    {
        // Marks an entity as new
        TEntity Add(TEntity entity);

        // Marks an entity as modified
        void Update(TEntity entity);

        // Marks an entity to be removed
        TEntity Delete(TEntity entity);

        TEntity Delete(TKey id);

        //Delete multi records
        void DeleteMulti(Expression<Func<TEntity, bool>> where);

        // Get an entity by int id
        TEntity GetSingleById(TKey id);

        TEntity GetSingleByCondition(Expression<Func<TEntity, bool>> expression, string[] includes = null);

        IEnumerable<TEntity> GetAll(string[] includes = null);

        IEnumerable<TEntity> GetMulti(Expression<Func<TEntity, bool>> predicate, string[] includes = null);

        IEnumerable<TEntity> GetMultiPaging(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        int Count(Expression<Func<TEntity, bool>> where);

        bool CheckContains(Expression<Func<TEntity, bool>> predicate);
    }
}