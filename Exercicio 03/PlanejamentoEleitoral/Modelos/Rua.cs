namespace PlanejamentoEleitoral.Modelos;

public class Rua
{
    private string cep;
    private string nome;

    public Rua(string Cep, string Nome)
    {
        AtualizarNome(Nome);
        AtualizarCep(Cep);
    }

    public void AtualizarNome(string novoNome)
    {
        ValidarValorVazioOuNulo(novoNome, "nome");
        this.nome = novoNome;
    }
    public void AtualizarCep(string novoCep)
    {
        string valorCep = RetornarApenasNumeros(novoCep);
        ValidarValorVazioOuNulo(valorCep, "cep");
        ValidarCep(valorCep);
        this.cep = FormatarCep(valorCep);
    }

    public string ObterNome()
    {
        return nome;
    }
    public string ObterCep()
    {
        return cep;
    }

    private void ValidarValorVazioOuNulo(string valor, string campo)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            throw new ArgumentException($"O {campo} da rua não pode ser vazio ou nulo");
        }
    }
    private string RetornarApenasNumeros(string valor)
    {
        //Método para remover qualquer caracter não numérico
        return new string(valor.Where(char.IsDigit).ToArray());
    }
    private void ValidarCep(string cep)
    {
        // Verificar se o CEP numérico tem o formato correto (8 dígitos)
        if (cep.Length != 8 || !int.TryParse(cep, out _))
        {
            throw new ArgumentException("CEP inválido. Deve conter exatamente 8 dígitos");
        }
    }
    private string FormatarCep(string cep)
    {
        // Formatar o CEP para o padrão XXXXX-XXX
        return $"{cep.Substring(0, 5)}-{cep.Substring(5)}";
    }
}
