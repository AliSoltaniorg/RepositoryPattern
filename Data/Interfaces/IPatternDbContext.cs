using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPatternDbContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Comment> Comments { get; set; }

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

        DbSet<TEntity> Set<TEntity>() where TEntity :class;

        void Dispose();
    }
}
