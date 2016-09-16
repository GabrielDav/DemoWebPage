using System;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
