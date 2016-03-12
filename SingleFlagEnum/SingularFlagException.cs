using System;

namespace SingularFlagEnumeration {
    public class SingularFlagException : Exception {
        public SingularFlagException() { }

        public SingularFlagException(string message) : base(message) { }
    }
}
