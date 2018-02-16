using System.Collections.Generic;

namespace Repositories.Interfaces.Base
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        void Save(T entity);
    }
}
