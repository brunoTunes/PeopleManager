using Application_Services;
using Domain;
using System;
using Xunit;

namespace ApplicationServices.Test
{
    public class PersonServiceTest
    {
        [Fact]
        public void Add_Vacation_Return_PersonDTO()
        {
            PersonService personService = new PersonService();

            var personDTO = personService.AddVacation(1, new Vacation(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2)));

            personDTO.Vacations.Should().NotBeEmptyOrNull();
        }
    }
}
