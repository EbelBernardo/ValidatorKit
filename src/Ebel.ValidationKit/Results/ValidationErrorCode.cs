namespace Ebel.ValidationKit.Results;

public enum ValidationErrorCode
{
    None = 0,

    // Cpf
    CpfRequired,
    CpfInvalidLength,
    CpfBlacklisted,
    CpfInvalidCheckDigit,

    // NameV
    NameRequired,
    NameInvalidCharacters
}