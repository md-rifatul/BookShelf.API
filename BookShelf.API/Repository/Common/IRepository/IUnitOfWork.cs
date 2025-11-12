namespace BookShelf.API.Repository.Common.IRepository
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
