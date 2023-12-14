namespace WebApi.Net8_Versioning_MinimalAPi.Contract.Shared;

public class Result
{
    protected Result(bool isSuccess, Error errors)
    {
        switch (isSuccess)
        {
            case true when errors != Error.None:
                throw new InvalidOperationException("Success result can't contain errors.");
            case false when errors == Error.None:
                throw new InvalidOperationException("Failed result must contain errors.");
            default:
                IsSuccess = isSuccess;
                Errors = errors;
                break;
        }
    }

    public Error Errors { get; set; }
    public bool IsSuccess { get; set; }
    public bool IsFailure => !IsSuccess;

    public static Result Success()
    {
        return new Result(true, Error.None);
    }

    private static ResultT<TValue> Success<TValue>(TValue value)
    {
        return new ResultT<TValue>(value, true, Error.None);
    }

    public static Result Failure(Error error)
    {
        return new Result(false, error);
    }

    private static ResultT<TValue> Failure<TValue>(Error error)
    {
        return new ResultT<TValue>(default, false, error);
    }

    protected static ResultT<TValue> Create<TValue>(TValue? value)
    {
        return value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
    }
}