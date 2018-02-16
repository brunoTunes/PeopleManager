using Domain;
using System.Collections.Generic;

namespace Application_Services.PersonService
{
    public class PersonDTO
    {

        public List<Vacation> Vacations { get; set; }

        public PersonDTO(List<Vacation> vacations)
        {
            Vacations = vacations;
        }
    }
}