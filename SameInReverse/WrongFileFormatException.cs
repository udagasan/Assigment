using System;
using System.Runtime.Serialization;

namespace SameInReverse
{
    [Serializable]
    internal class WrongFileFormatException : Exception
    {
        public WrongFileFormatException()
        {
        }

        public WrongFileFormatException(string message) : base(message)
        {
            message = "Process only run for .sdx file" + message;

        }

        public WrongFileFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongFileFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}