using AuthServer.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AuthServer.DataAccess.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(AuthDbContext authDbContext)
        {
            _context = authDbContext;
            _dbSet= authDbContext.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public IQueryable<TEntity> GetAllAsync()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity=await _dbSet.FindAsync(id);
            if(entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity ?? Activator.CreateInstance<TEntity>();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State=EntityState.Modified;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
