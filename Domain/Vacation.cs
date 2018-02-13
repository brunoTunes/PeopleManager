using Domain.Shared;
using System;
using System.Globalization;

namespace Domain
{
    public class Vacation : ValueObject<Vacation>
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public Vacation(DateTime start, DateTime end)
        {
            if (end < start)
                throw new InvalidOperationException();

            if (end < DateTime.UtcNow || start < DateTime.UtcNow)
                throw new InvalidOperationException();

            Start = start.Date;
            End = end.Date;
        }

        public override bool Equals(object other)
        {
            var otherObj = other as Vacation;

            if (otherObj == null)
                return false;

            return otherObj.End == End && otherObj.Start == Start;
        }

        public override int GetHashCode()
        {
            return (Start + End.ToString(CultureInfo.InvariantCulture)).GetHashCode();
        }

        public bool Overlaps(Vacation other)
        {
            return (other.Start <= End && other.Start >= Start) 
                   || (other.End <= End && other.End >= Start) 
                   || (Start < other.End && Start > other.Start) 
                   || (End <= other.End && End >= other.Start);
        }
    }
}
