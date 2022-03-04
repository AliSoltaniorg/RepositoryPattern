using Core.Common.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Common.Services
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>, IBaseRepository<TEntity, TKey> where TEntity : class
    {
        private DbSet<TEntity> _dbSet;
        private PatternDbContext _context;
        public Repository(PatternDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>(); 
        }


        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(TKey key)
        {
            var entity = FindOrDefault(key);
            if (entity != null)
                Delete(entity);
        }

        public TEntity FindOrDefault(TKey key)
        {
            var entity = _dbSet.Find(key);
            if(entity != null)
                return entity;
            return null;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> perdicate = null)
        {
            if(perdicate != null)
            {
                var entity = _dbSet.Where(perdicate).FirstOrDefault();
                return entity;
            }
            return _dbSet.FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> perdicate = null)
        {
            if (perdicate != null)
            {
                var entity = _dbSet.Where(perdicate).ToList();
                return entity;
            }
            return _dbSet.ToList();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
