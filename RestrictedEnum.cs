public class RestrictedEnum<T> where T : struct {
    private System.Enum value;
    public T Value { get { return (T)(object)value; } }

    public RestrictedEnum() {
        if ( !typeof(T).IsEnum ) throw new NotSupportedException();
        value = null;
    }

    public RestrictedEnum( Enum flag ) {
        if ( !typeof(T).IsEnum ) throw new NotSupportedException();
        SetFlag( flag );
    }

    public bool SetFlag( Enum flag ) {
        bool checkEnum = Enum.IsDefined( typeof( T ), flag );
        if ( checkEnum ) value = flag;
        return checkEnum;
    }

    public bool HasFlag( Enum flag ) {
        return ( Enum.IsDefined( typeof( T ), flag ) ) ? Enum.Equals( value, flag ) : false;
    }

    public T Parse() {
        return (T)(object)value;
    }
}
