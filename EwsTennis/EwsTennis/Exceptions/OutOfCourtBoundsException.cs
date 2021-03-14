using System;

namespace EwsTennis.Exceptions
{

    [Serializable]
    public class OutOfCourtBoundsException : Exception
    {
        public OutOfCourtBoundsException(string message) : base(message) { }
    }
}
