namespace Core.Common.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : class where TKey : struct , IBaseRepository<TEntity, TKey>
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(TKey key);
    }
}
