public class RestrictedEnum<T> where T : struct, IComparable {
    /// <summary>Gets the flag set for this object.</summary>
    public T Flag { get; private set; }

    /// <summary>Gets an array of member values of the underlying enumeraton.</summary>
    public T[] Values {
        get {
            return (T[])Enum.GetValues(typeof(T));
        }
    }

    /// <summary>Gets an array of member names of the underlying enumeratio.</summary>
    public string[] Names {
        get {
            return Enum.GetNames(typeof(T));
        }
    }

    /// <summary>Constructs a RestrictedEnum<T> with the default value of T.</summary>
    public RestrictedEnum() {
        if(!typeof(T).IsEnum)
            throw new NotSupportedException();
    }

    /// <summary>Constructs a RestrictedEnum<T> with the provided flag of type T.</summary>
    /// <param name="flag">Flag to set.</param>
    public RestrictedEnum(T flag) : this() {
        SetFlag(flag);
    }

    /// <summary>Parses a member name into a member of type T if possible, otherwise null is returned.</summary>
    /// <param name="name">Name of the member to parse.</param>
    /// <returns>A nullable value of type T of the member that was parsed.</returns>
    public T? Parse(string name) {
        T value;
        return Enum.TryParse<T>(name, out value) ? (T?)value : null;
    }

    /// <summary>Gets a dictionary with a key-value pair of each enum member names and values.</summary>
    /// <returns>A Dictionary of key-value pair (string, T) where each key-value pair represents a member in an Enum.</returns>
    public IDictionary<string, T> Members() {
        Dictionary<string, T> members = new Dictionary<string, T>();

        foreach(string name in Names)
            members.Add(name, (T)Enum.Parse(typeof(T), name));

        return members;
    }

    /// <summary>Attempts to set the defined flag if it exists in the Enum.</summary>
    /// <param name="flag">Enum flag to set.</param>
    /// <returns>True if the flag was set, false if the flag does not exist or the flag is already set.</returns>
    public bool SetFlag(T flag) {
        bool check = Enum.Equals(Flag, flag) && Enum.IsDefined(typeof(T), flag);
        if(check)
            Flag = flag;
        return check;
    }

    /// <summary>Gets whether the provided flag is equal to the set flag.</summary>
    /// <param name="flag">Flag to check.</param>
    /// <returns></returns>
    public bool HasFlag(T flag) =>
        Enum.Equals(Flag, flag);

    /// <summary>Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.</summary>
    /// <param name="obj">Object to compare.</param>
    /// <returns> A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes obj in the sort order. Zero This instance occurs in the same position in the sort order as obj. Greater than zero This instance follows obj in the sort order.</returns>
    public int CompareTo(RestrictedEnum<T> obj) =>
        Flag.CompareTo(obj.Flag);

    /// <summary>Gets whether the the flag of an object is the same as the provided flag.</summary>
    /// <param name="obj">Object to compare the flag to.</param>
    /// <param name="flag">Flag to compare the object to.</param>
    /// <returns>True if the flag is the same as the flag of the object, else false.</returns>
    public static bool operator ==(RestrictedEnum<T> obj, T flag) =>
        obj.HasFlag(flag);

    /// <summary>Gets whether two objects contain the same flag.</summary>
    /// <param name="obj1">First object to compare.</param>
    /// <param name="obj2">Second object to compare.</param>
    /// <returns>True if the flag of each object is the same, else false.</returns>
    public static bool operator ==(RestrictedEnum<T> obj1, RestrictedEnum<T> obj2) =>
        obj1.HasFlag(obj2.Flag);

    /// <summary>Gets whether the the flag of an object is NOT the same as the provided flag.</summary>
    /// <param name="obj">Object to compare the flag to.</param>
    /// <param name="flag">Flag to compare the object to.</param>
    /// <returns>True if the flag is NOT the same as the flag of the object, else false.</returns>
    public static bool operator !=(RestrictedEnum<T> obj, T flag) =>
        !obj.HasFlag(flag);

    /// <summary>Gets whether two objects do NOT contain the same flag.</summary>
    /// <param name="obj1">First object to compare.</param>
    /// <param name="obj2">Second object to compare.</param>
    /// <returns>True if the flag of each object is NOT the same, else false.</returns>
    public static bool operator !=(RestrictedEnum<T> obj1, RestrictedEnum<T> obj2) =>
        !obj1.HasFlag(obj2.Flag);

    /// <summary>Gets the type of T of this object.</summary>
    /// <returns>The underlying type of the enum of T of this generic object.</returns>
    public Type GetEnumType() =>
        typeof(T);

    /// <summary>Gets whether two objects equal (they share the same reference).</summary>
    /// <param name="obj">Object to compare.</param>
    /// <returns>True if the provided object is equal to this object.</returns>
    public bool Equals(RestrictedEnum<T> obj) =>
        this == obj;

    /// <summary>Determines whether the specified object is equal to the current object.</summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>True if the specified object is equal to the current object, else false.</returns>
    public override bool Equals(object obj) =>
        base.Equals(obj);

    /// <summary>Gest the hash code for the current object.</summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode() =>
        base.GetHashCode();
}
