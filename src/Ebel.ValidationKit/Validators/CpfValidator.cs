using Ebel.ValidationKit.Results;

namespace Ebel.ValidationKit.Validators;

public static class CpfValidator
{
    public static ValidationResult ValidateCpf(this string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return ValidationResult.Fail(ValidationErrorCode.CpfRequired, "CPF is required");

        var cleaned = new string(cpf.Where(char.IsDigit).ToArray());
        if (cleaned.Length != 11)
            return ValidationResult.Fail(ValidationErrorCode.CpfInvalidLength, "CPF must contain 11 digits");

        if (cleaned.All(c => c == cleaned[0]))
            return ValidationResult.Fail(ValidationErrorCode.CpfBlacklisted, "Invalid CPF");

        if (!CpfDigitCalculator.IsValidCpf(cleaned))
            return ValidationResult.Fail(ValidationErrorCode.CpfInvalidCheckDigit, "Invalid CPF");

        return ValidationResult.Success();
    }
}