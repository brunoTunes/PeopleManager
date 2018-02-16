using Repositories.Interfaces;
using System.Data;
using System.Data.Entity;
using Mappings;

namespace Repositories.UnitOfWork
{
    public class EFUnitOfWork : IEFUnitOfWork
    {
        private DbContext context;
        private DbContextTransaction transaction;

        public EFUnitOfWork()
        {
            //TODO Better Context Managing -> http://mehdi.me/ambient-dbcontext-in-ef6/
            context = new PeopleManagerContext();
        }

        public void OpenTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (transaction == null)
            {
                if (transaction != null)
                    transaction.Dispose();

                transaction = context.Database.BeginTransaction(isolationLevel);
            }
        }

        public void Commit()
        {
            try
            {
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Dispose()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }

            if (context != null)
            {
                context.Database.Connection.Close();
                context.Dispose();
                context = null;
            }
        }

        public DbContext GetContext()
        {
            return context;
        }
    }
}
