namespace Ebel.ValidationKit.Results;

public class ValidationResult()
{
    public bool IsValid { get; set; }
    public ValidationErrorCode Code { get; set; }
    public string Message { get; set; } = string.Empty;

    public static ValidationResult Success()
        => new()
        {
            IsValid = true,
            Code = ValidationErrorCode.None
        };

    public static ValidationResult Fail(ValidationErrorCode code, string message)
        => new()
        {
            IsValid = false,
            Code = code,
            Message = message
        };
}