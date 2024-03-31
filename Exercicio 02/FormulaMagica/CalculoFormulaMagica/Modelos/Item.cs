namespace CalculoFormulaMagica.Modelos;

public class Item
{
    private string nome;
    private double custo;
    private double valorVenda;
    private int validade;

    public Item(string nome, double custo, int validade)
    {
        AtualizarNome(nome);
        AtualizarCusto(custo);
        AtualizarValidade(validade);
    }

    public void AtualizarNome(string novoNome)
    {
        ValidarValorVazioOuNulo(novoNome, "nome do item");
        this.nome = novoNome;
    }
    public void AtualizarCusto(double novoCusto)
    {
        ValidarValorNegativoOuIgualZero(novoCusto, "custo");
        this.custo = novoCusto;
    }
    public void AtualizarValorVenda(double novoValorVenda)
    {
        ValidarValorNegativoOuIgualZero(novoValorVenda, "venda");
        this.valorVenda = novoValorVenda;
    }

    public void AtualizarValidade(int novaValidade)
    {
        ValidarValorNegativoOuIgualZero(novaValidade, "validade");
        this.validade = novaValidade;
    }

    public string ObterNome()
    {
        return nome;
    }
    public double ObterValorVenda()
    {
        return valorVenda;
    }

    public double ObterCusto()
    {
        return custo;
    }

    public int ObterValidade()
    {
        return validade;
    }

    private void ValidarValorVazioOuNulo(string valor, string campo)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            throw new ArgumentException($"O {campo} do item não pode ser vazio ou nulo");
        }
    }
    private void ValidarValorNegativoOuIgualZero(double valor, string campo)
    {
        if (valor <= 0)
        {
            throw new ArgumentException($"O valor de {campo} não pode ser negativo ou igual a zero");
        }
    }

    private void ValidarValorNegativoOuIgualZero(int valor, string campo)
    {
        if (valor <= 0)
        {
            throw new ArgumentException($"O valor de {campo} não pode ser negativo ou igual a zero");
        }
    }
}
