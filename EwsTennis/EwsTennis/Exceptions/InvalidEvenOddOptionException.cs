using System;

namespace EwsTennis.Exceptions
{

    [Serializable]
    public class InvalidEvenOddOptionException : Exception
    {
        public InvalidEvenOddOptionException() { }
        public InvalidEvenOddOptionException(string message) : base(message) { }
    }
}
