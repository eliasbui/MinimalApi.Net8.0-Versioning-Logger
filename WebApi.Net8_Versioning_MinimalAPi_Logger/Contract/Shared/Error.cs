namespace WebApi.Net8_Versioning_MinimalAPi.Contract.Shared;

/// <summary>
///     Represents an error with a code and a message.
///     Implements the IEquatable interface for equality comparison.
/// </summary>
public sealed class Error : IEquatable<Error> // Equatable is used for testing purposes.
{
    /// <summary>
    ///     Represents no error.
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty);

    /// <summary>
    ///     Represents an unknown error.
    /// </summary>
    public static readonly Error Unknown = new("Unknown", "An unknown error has occurred.");

    /// <summary>
    ///     Represents a null value error.
    /// </summary>
    public static readonly Error NullValue = new("Error.NullValue", "The value cannot be null.");

    /// <summary>
    ///     Initializes a new instance of the Error class.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="message">The error message.</param>
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    /// <summary>
    ///     Gets the error code.
    /// </summary>
    public string Code { get; }

    /// <summary>
    ///     Gets the error message.
    /// </summary>
    public string Message { get; }

    /// <summary>
    ///     Determines whether the specified Error is equal to the current Error.
    /// </summary>
    /// <param name="other">The Error to compare with the current Error.</param>
    /// <returns>true if the specified Error is equal to the current Error; otherwise, false.</returns>
    public bool Equals(Error? other)
    {
        if (other is null) return false;
        return Code == other.Code && Message == other.Message;
    }

    /// <summary>
    ///     Gets the hash code for this instance.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Code, Message);
    }

    /// <summary>
    ///     Converts an Error to a string by returning its code.
    /// </summary>
    /// <param name="error">The error to convert.</param>
    public static implicit operator string(Error error)
    {
        return error.Code;
    }

    /// <summary>
    ///     Determines whether two Error instances are equal.
    /// </summary>
    /// <param name="a">The first Error to compare.</param>
    /// <param name="b">The second Error to compare.</param>
    /// <returns>true if the instances are equal; otherwise, false.</returns>
    public static bool operator ==(Error? a, Error? b)
    {
        if (a is null && b is null) return true; // This is the implementation of IEquatable<Error>.
        if (a is null || b is null) return false; // This is the implementation of IEquatable<Error>.

        return a.Equals(b); // This is the implementation of IEquatable<Error>.
    }

    /// <summary>
    ///     Determines whether two Error instances are not equal.
    /// </summary>
    /// <param name="a">The first Error to compare.</param>
    /// <param name="b">The second Error to compare.</param>
    /// <returns>true if the instances are not equal; otherwise, false.</returns>
    public static bool operator !=(Error? a, Error? b)
    {
        return !(a == b);
    }

    /// <summary>
    ///     Determines whether the specified object is equal to the current Error.
    /// </summary>
    /// <param name="obj">The object to compare with the current Error.</param>
    /// <returns>true if the specified object is equal to the current Error; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        return obj is Error other && Equals(other);
    }
}