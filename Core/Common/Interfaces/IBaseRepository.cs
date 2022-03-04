using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Common.Interfaces
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class where TKey : struct
    {
        TEntity FindOrDefault(TKey key);

        TEntity FirstOrDefault(Expression<Func<bool,TEntity>> perdicate);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(Expression<Func<bool, TEntity>> perdicate);
    }
}
