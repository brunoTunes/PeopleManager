using Domain.Shared;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public sealed class Person : Entity
    {
        public List<Vacation> Vacations { get; } = new List<Vacation>();

        public Person()
        {
        }

        public void Add(Vacation vacation)
        {
            if(!Vacations.Any(vacationInList => vacationInList.Overlaps(vacation)))
                Vacations.Add(vacation);
        }

        public void Remove(Vacation vacation)
        {
            Vacations.Remove(vacation);
        }
    }
}
