using AuthServer.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(AuthDbContext authDbContext)
        {
            _dbContext = authDbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
