using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Common.Interfaces
{

    public interface IBaseRepository<TEntity, TKey>
    {
        TEntity FindOrDefault(TKey key);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> perdicate);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> perdicate);
    }
}
