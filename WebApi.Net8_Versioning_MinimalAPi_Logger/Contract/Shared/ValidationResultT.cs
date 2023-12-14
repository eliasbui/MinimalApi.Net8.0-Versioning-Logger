namespace WebApi.Net8_Versioning_MinimalAPi.Contract.Shared;

public class ValidationResultT<T> : ResultT<T>, IValidationResult
{
    protected internal ValidationResultT(Error[] errors) : base(default!, false, IValidationResult.ValidationErrors)
    {
        Errors = errors;
    }

    public Error[] Errors { get; }

    public static ValidationResultT<T> WithErrors(Error[] errors)
    {
        return new ValidationResultT<T>(errors);
    }
}