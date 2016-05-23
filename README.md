# Unsocial\<T\>
Allows you to create an immutable instance that can only hold a single flag from any given enumeration. Overloads all comparison and cast operators for comparison between Unsocial<T> and T directly.

```C#
// Implementation:
class Unsocial<T> {
  Unsocial();
  Unsocial(T);
  
  static Unsocial<T> Parse(string);
  static Unsocial<T> Get(T);
  Type GetGenericType();
  
   bool operator ==(Unsocial<T>, Unsocial<T>);
   bool operator !=(Unsocial<T>, Unsocial<T>);
   implicit operator T(Unsocial<T>);
   implicit operator Unsocial<T>(T);
  
  int CompareTo(Unsocial<T>);
   Equals(Unsocial<T>);
   int GetHashCode();
}
```
