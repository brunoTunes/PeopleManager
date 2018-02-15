using System.Data;
using System.Data.Entity;

namespace Repositories.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DbContext context;
        private DbContextTransaction transaction;
        public DbContext Context { get { return context; } }

        public EFUnitOfWork()
        {
            //TODO Create Context and use it here -> context = dbContext;
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
    }
}
