namespace Repositories.UnitOfWork
{
    interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
