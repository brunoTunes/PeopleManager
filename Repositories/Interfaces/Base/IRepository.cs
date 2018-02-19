using System.Collections.Generic;
using System.Linq;

namespace Repositories.Interfaces.Base
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetById(int Id);
        void Save(T entity);
    }
}
