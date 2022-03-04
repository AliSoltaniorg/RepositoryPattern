using System.Threading.Tasks;

namespace Core.Common.Interfaces
{
    public interface IAsyncRepository<TEntity, TKey> : IAsyncBaseRepository<TEntity,TKey>
    {
        Task AddAsync(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task Delete(TKey key);
    }
}
