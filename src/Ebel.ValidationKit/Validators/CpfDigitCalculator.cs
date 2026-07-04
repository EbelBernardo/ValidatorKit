using System.ComponentModel.DataAnnotations;

namespace Ebel.ValidationKit.Validators;

public static class CpfDigitCalculator
{
    public static bool IsValidCpf(string cpf)
    {
        var number = cpf.Select(c => c - '0').ToArray();

        var sum1 = 0;

        for (var i = 0; i < 9; i++)
            sum1 += number[i] * (10 - i);

        var rest_d1 = sum1 % 11;

        var d1 = rest_d1 < 2 ? 0 : 11 - rest_d1;


        var sum2 = 0;
        for (var i = 0; i < 9; i++)
            sum2 += number[i] * (11 - i);
        sum2 += d1 * 2;

        var rest_d2 = sum2 % 11;

        var d2 = rest_d2 < 2 ? 0 : 11 - rest_d2;

        return number[9] == d1 && number[10] == d2;
    }
}