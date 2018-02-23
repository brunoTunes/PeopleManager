namespace Domain.Shared
{
    public abstract class Entity
    {
        public int Id { get; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (compareTo is null)
                return false;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (GetType() != compareTo.GetType())
                return false;

            return Id == compareTo.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
