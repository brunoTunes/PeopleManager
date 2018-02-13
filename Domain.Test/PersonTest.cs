using System;
using FluentAssertions;
using Xunit;

namespace Domain.Test
{
    public class PersonTest
    {
        [Fact]
        public void No_Vacation_When_Created()
        {
            var person = new Person();

            person.Vacations.Should().BeEmpty();
        }

        [Fact]
        public void Add_Vacation_Should_Have_Vacation()
        {
            var person = new Person();
            var vacation = new Vacation(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));

            person.AddVacation(vacation);

            person.Vacations.Should().HaveCount(1);
            person.Vacations.Should().Contain(vacation);
        }

        [Fact]
        public void Add_Vacation_Overlaping_Other_Should_Not_Add()
        {
            var person = new Person();
            var vacation1 = new Vacation(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));
            var vacation2 = new Vacation(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(3));

            person.AddVacation(vacation1);
            person.AddVacation(vacation2);

            person.Vacations.Should().HaveCount(1);
            person.Vacations.Should().Contain(vacation1);
        }

        [Fact]
        public void Remove_Vacation_Should_Have_No_Vacation()
        {
            var person = new Person();
            var vacation = new Vacation(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));

            person.AddVacation(vacation);
            person.RemoveVacation(vacation);

            person.Vacations.Should().BeEmpty();
        }
    }
}
