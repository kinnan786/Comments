namespace SMOAPP.Data.Interface
{
    public interface IUnitOfWork
    {
        IRepository<T> RepoOf<T>() where T : class;

        void Commit();

        T Repo<T>() where T : class;
    }
}