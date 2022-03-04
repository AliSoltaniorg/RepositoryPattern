using Core.Common.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Common.Services
{
    public class AsyncRepository<TEntity, TKey> : IAsyncRepository<TEntity, TKey>, IAsyncBaseRepository<TEntity, TKey> where TEntity : class
    {
        private DbSet<TEntity> _dbSet;
        private PatternDbContext _context;
        public AsyncRepository(PatternDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task Delete(TEntity entity)
        {
            _context.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task Delete(TKey key)
        {
            var entity = await FindOrDefault(key);
            if (entity != null)
                await Delete(entity);
        }

        public async Task<TEntity> FindOrDefault(TKey key)
        {
            var entity = await _dbSet.FindAsync(key);
            if(entity != null)
                return entity;
            return null;
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> perdicate)
        {
            if (perdicate != null)
            {
                var entity = await _dbSet.Where(perdicate).FirstOrDefaultAsync();
                return entity;
            }
            return await _dbSet.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> perdicate)
        {
            if (perdicate != null)
            {
                var entity = await _dbSet.Where(perdicate).ToListAsync();
                return entity;
            }
            return await _dbSet.ToListAsync();
        }

        public Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }
    }
}
