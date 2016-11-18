namespace BaseSource.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}