using Ebel.ValidationKit.Results;
using Ebel.ValidationKit.Validators;

namespace Ebel.ValidatorKit.Test.Validators;

[TestClass]
public sealed class CpfValidatorTests
{
    [TestMethod]
    public void Should_Fail_When_Cpf_Is_Empty()
    {
        string cpf = "";

        var result = cpf.ValidateCpf();

        Assert.IsFalse(result.IsValid);
        Assert.AreEqual(ValidationErrorCode.CpfRequired, result.Code);
        Assert.AreEqual("CPF is required", result.Message);
    }

    [TestMethod]
    public void Should_Fail_When_Cpf_Has_Less_Than_11_Digits()
    {
        string cpf = "123123";

        var result = cpf.ValidateCpf();

        Assert.IsFalse(result.IsValid);
        Assert.AreEqual(ValidationErrorCode.CpfInvalidLength, result.Code);
        Assert.AreEqual("CPF must contain 11 digits", result.Message);

        cpf = "123123123123123";

        result = cpf.ValidateCpf();

        Assert.IsFalse(result.IsValid);
        Assert.AreEqual(ValidationErrorCode.CpfInvalidLength, result.Code);
        Assert.AreEqual("CPF must contain 11 digits", result.Message);
    }

    [TestMethod]
    public void Should_Fail_When_Cpf_Has_Only_Repeated_Digits()
    {
        string[] invalidCpfs =
        {
            "00000000000",
            "11111111111",
            "22222222222",
            "99999999999"
        };

        foreach (var cpf in invalidCpfs)
        {
            var result = cpf.ValidateCpf();

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(ValidationErrorCode.CpfBlacklisted, result.Code);
            Assert.AreEqual("Invalid CPF", result.Message);
        }
    }

    [TestMethod]
    public void Should_Fail_When_Cpf_Has_Invalid_Digits()
    {
        var cpf = "12345678912";

        var result = cpf.ValidateCpf();

        Assert.IsFalse(result.IsValid);
        Assert.AreEqual(ValidationErrorCode.CpfInvalidCheckDigit, result.Code);
        Assert.AreEqual("Invalid CPF", result.Message);
    }

    [TestMethod]
    public void Should_Pass_When_Cpf_Is_Valid()
    {
        string[] validCpfs =
        {
            "52998224725",
            "12345678909",
            "11144477735"
        };

        foreach (var cpf in validCpfs)
        {
            var result = cpf.ValidateCpf();

            Assert.IsTrue(result.IsValid);
        }
    }
}
