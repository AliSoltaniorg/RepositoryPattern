using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Common.Interfaces
{

    public interface IBaseRepository<TEntity, TKey>
    {
        TEntity FindOrDefault(TKey key);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> perdicate);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> perdicate);
    }

    public interface IAsyncBaseRepository<TEntity, TKey>
    {
        Task<TEntity> FindOrDefault(TKey key);

        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> perdicate);

        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> perdicate);
    }
}
