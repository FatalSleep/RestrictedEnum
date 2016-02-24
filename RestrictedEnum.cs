public class RestrictedEnum<T> where T : struct, IComparable {
    public T Flag { get; private set; }

    public T[] Values {
        get {
            return (T[])Enum.GetValues(typeof(T));
        }
    }

    public string[] Names {
        get {
            return Enum.GetNames(typeof(T));
        }
    }

    public RestrictedEnum() {
        if(!typeof(T).IsEnum)
            throw new NotSupportedException();
    }

    public RestrictedEnum(T flag) : this() {
        SetFlag(flag);
    }

    public T? Parse(string name) {
        T value;
        return Enum.TryParse<T>(name, out value) ? (T?)value : null;
    }

    public IDictionary<string, T> Members() {
        Dictionary<string, T> members = new Dictionary<string, T>();

        foreach(string name in Names)
            members.Add(name, (T)Enum.Parse(typeof(T), name));

        return members;
    }

    public bool SetFlag(T flag) {
        bool check = Enum.Equals(Flag, flag) && Enum.IsDefined(typeof(T), flag);
        if(check)
            Flag = flag;
        return check;
    }

    public bool HasFlag(T flag) =>
        Enum.Equals(Flag, flag);

    public int CompareTo(RestrictedEnum<T> obj) =>
        Flag.CompareTo(obj.Flag);

    public static bool operator ==(RestrictedEnum<T> obj1, T obj2) =>
        obj1.HasFlag(obj2);

    public static bool operator ==(RestrictedEnum<T> obj1, RestrictedEnum<T> obj2) =>
        obj1.HasFlag(obj2.Flag);

    public static bool operator !=(RestrictedEnum<T> obj1, T obj2) =>
        !obj1.HasFlag(obj2);

    public static bool operator !=(RestrictedEnum<T> obj1, RestrictedEnum<T> obj2) =>
        !obj1.HasFlag(obj2.Flag);

    public Type GetEnumType() =>
        typeof(T);

    public bool Equals(RestrictedEnum<T> obj) =>
        this == obj;

    public override bool Equals(object obj) =>
        base.Equals(obj);

    public override int GetHashCode() =>
        base.GetHashCode();
}
