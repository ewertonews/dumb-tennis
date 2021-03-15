using System;

namespace EwsTennis.Exceptions
{
    [Serializable]
    public class InvalidFileException : Exception
    {
        public InvalidFileException(string message) : base(message) { }
    }
}
