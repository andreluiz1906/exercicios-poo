using DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Interfaces.Validadores;

namespace DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Modelos.Validadores;

public class ValidadorCPF : IValidador<string>
{
    public bool Validar(string cpf)
    {
        // Valida se o valor informado não está nulo ou contem apenas espaços
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        // Remove caracteres não numéricos
        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        // Verifica se o CPF possui 11 dígitos
        if (cpf.Length != 11)
            return false;

        // Verifica se todos os dígitos são iguais
        if (cpf.Distinct().Count() == 1)
            return false;

        // Calcula o primeiro dígito verificador
        int soma = 0;
        for (int i = 0; i < 9; i++)
            soma += int.Parse(cpf[i].ToString()) * (10 - i);
        int resto = soma % 11;
        int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

        // Calcula o segundo dígito verificador
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(cpf[i].ToString()) * (11 - i);
        resto = soma % 11;
        int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

        // Verifica se os dígitos verificadores estão corretos
        return cpf[9] - '0' == digitoVerificador1 && cpf[10] - '0' == digitoVerificador2;
    }
}
