namespace WebApi.Net8_Versioning_MinimalAPi.Contract.Shared;

public class ValidationResult : Result, IValidationResult
{
    protected internal ValidationResult(Error[] errors) : base(false, IValidationResult.ValidationErrors)
    {
        Errors = errors;
    }

    public Error[] Errors { get; }

    public static ValidationResult WithErrors(Error[] errors)
    {
        return new ValidationResult(errors);
    }
}