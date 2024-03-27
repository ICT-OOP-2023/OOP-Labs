using System.Runtime.Serialization;

namespace OOP_ICT.Fourth.Exceptions;

public class BetException : Exception
{
    public BetException()
    {
    }

    protected BetException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public BetException(string? message) : base(message)
    {
    }

    public BetException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}