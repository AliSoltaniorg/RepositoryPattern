using System.Threading.Tasks;

namespace Core.Common.Interfaces
{
    public interface IAsyncRepository<TEntity, TKey> where TEntity : class where TKey : struct , IBaseRepository<TEntity,TKey>
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task Delete(TKey key);;
    }
}
