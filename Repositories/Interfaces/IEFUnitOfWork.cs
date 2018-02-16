using Repositories.UnitOfWork;
using System.Data;
using System.Data.Entity;

namespace Repositories.Interfaces
{
    public interface IEFUnitOfWork : IUnitOfWork
    {
        DbContext GetContext();
        void OpenTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}
