namespace AuthServer.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
