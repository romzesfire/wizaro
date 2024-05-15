namespace Magic.Service.Validation;

public class TypeComparer : IEqualityComparer<Type>
{
    public bool Equals(Type? x, Type? y)
    {
        return x is not null && y is not null && x.FullName == y.FullName;
    }

    public int GetHashCode(Type obj)
    {
        return obj.GetHashCode();
    }
}