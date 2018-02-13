namespace Domain.Shared
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();

        public static bool operator == (ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator != (ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
