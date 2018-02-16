using Domain;
using Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;

namespace Application_Services.PersonService
{
    public class PersonService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public PersonDTO AddVacation(int personId, Vacation vacation)
        {
            var person = _personRepository.GetById(personId);

            if (person == null)
                throw new InvalidOperationException();

            person.Add(vacation);

            _personRepository.Save(person);

            //TODO Automap dtos
            return new PersonDTO(new List<Vacation> { vacation });
        }
    }
}
