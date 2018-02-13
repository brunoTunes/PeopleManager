using FluentAssertions;
using System;
using Xunit;

namespace Domain.Test
{
    public class VacationTest
    {
        [Fact]
        public void Cannot_Create_End_Time_Before_Start_Times()
        {
            Action action = () => new Vacation(DateTime.UtcNow.AddDays(5), DateTime.UtcNow.AddDays(2));

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Cannot_Create_Vacation_Past()
        {
            Action action = () => new Vacation(DateTime.UtcNow.Subtract(TimeSpan.FromDays(2)), DateTime.UtcNow.Subtract(TimeSpan.FromDays(1)));

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Two_Instances_Equal_If_Same_Start_And_End()
        {
            var vacation1 = new Vacation(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));
            var vacation2 = new Vacation(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));

            vacation1.Should().BeEquivalentTo(vacation2);
            vacation1.GetHashCode().Should().Be(vacation2.GetHashCode());
        }

        [Fact]
        public void Two_Instances_NotEqual_If_Start_Different()
        {
            var vacation1 = new Vacation(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));
            var vacation2 = new Vacation(DateTime.UtcNow.AddDays(2), DateTime.UtcNow.AddDays(2));

            vacation1.Should().NotBe(vacation2);
            vacation1.GetHashCode().Should().NotBe(vacation2.GetHashCode());
        }

        [Fact]
        public void Two_Instances_NotEqual_If_End_Different()
        {
            var vacation1 = new Vacation(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));
            var vacation2 = new Vacation(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(3));

            vacation1.Should().NotBe(vacation2);
            vacation1.GetHashCode().Should().NotBe(vacation2.GetHashCode());
        }

        [Theory]
        [InlineData(1, 1, 1, 3)]
        [InlineData(1, 3, 1, 1)]
        [InlineData(1, 5, 1, 3)]
        [InlineData(2, 3, 1, 5)]
        public void Two_Instances_Overlap_If_Start_Between(int start1, int end1, int start2, int end2)
        {
            var vacation1 = new Vacation(DateTime.UtcNow.AddDays(start1), DateTime.UtcNow.AddDays(end1));
            var vacation2 = new Vacation(DateTime.UtcNow.AddDays(start2), DateTime.UtcNow.AddDays(end2));

            vacation1.Overlaps(vacation2).Should().BeTrue();
            vacation2.Overlaps(vacation1).Should().BeTrue();
        }
    }
}
