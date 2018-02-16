using System.Collections.Generic;
using System.Linq;
using Domain;
using Repositories.Interfaces;
using Repositories.Interfaces.Base;

namespace Repositories.Implementations
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly IEFUnitOfWork _unitOfWork;

        public PersonRepository(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Person> GetAll()
        {
            _unitOfWork.OpenTransaction();
            return _unitOfWork.GetContext().Set<Person>().ToList();
        }

        public Person GetById(int Id)
        {
            _unitOfWork.OpenTransaction();
            return _unitOfWork.GetContext().Set<Person>().FirstOrDefault(person => person.Id == Id);
        }

        public void Save(Person person)
        {
            _unitOfWork.OpenTransaction();
            _unitOfWork.GetContext().Set<Person>().Add(person);
        }
    }
}
