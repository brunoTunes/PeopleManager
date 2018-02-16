using Application_Services.PersonService;
using Domain;
using FluentAssertions;
using Moq;
using Repositories.Interfaces.Base;
using System;
using Xunit;

namespace ApplicationServices.Test
{
    public class PersonServiceTest
    {
        private readonly Mock<IRepository<Person>> _personRepositoryMock;

        public PersonServiceTest()
        {
            _personRepositoryMock = new Mock<IRepository<Person>>();
        }

        [Fact]
        public void Add_Vacation_Return_PersonDTO()
        {
            PersonService personService = new PersonService(_personRepositoryMock.Object);
            Vacation vacation = new Vacation(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));
            _personRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Person());

            var personDTO = personService.AddVacation(1, vacation);

            personDTO.Vacations.Contains(vacation).Should().BeTrue();
        }

        [Fact]
        public void Add_Vacation_Non_Existing_Person_Throws()
        {
            PersonService personService = new PersonService(_personRepositoryMock.Object);
            Vacation vacation = new Vacation(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));
            _personRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns((Person) null);

            Action action = () => personService.AddVacation(1, vacation);

            action.Should().Throw<InvalidOperationException>();
        }
    }
}
