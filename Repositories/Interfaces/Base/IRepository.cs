using System.Collections.Generic;

namespace Repositories.Interfaces.Base
{
    interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById();
    }
}
