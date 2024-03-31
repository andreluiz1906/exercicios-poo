namespace PlanejamentoEleitoral.Modelos;

public class Casa
{
    private Rua rua;
    private int numero;
    private int totalEleitores;

    public Casa(Rua rua, int numero, int totalEleitores)
    {
        this.rua = rua;
        this.numero = numero;
        this.totalEleitores = totalEleitores;
    }
    public void AtualizarRua(Rua novaRua)
    {
        ValidarValorNulo(novaRua, "rua");
        this.rua = novaRua;
    }
    public void AtualizarNumero(int novoNumero)
    {
        ValidarValorVazioOuNulo(novoNumero, "número");
        this.numero = novoNumero;
    }
    public void AtualizarTotalEleitores(int novoTotalEleitores)
    {
        ValidarValorVazioOuNulo(novoTotalEleitores, "total de eleitores");
        this.totalEleitores = novoTotalEleitores;
    }

    public Rua ObterRua()
    {
        return rua;
    }
    public int ObterNumero()
    {
        return numero;
    }
    public int ObterTotalEleitores()
    {
        return totalEleitores;
    }

    private void ValidarValorNulo<T>(T valor, string campo)
    {
        if (valor == null)
        {
            throw new ArgumentException($"A {campo} da casa não pode ser nula");
        }
    }
    private void ValidarValorVazioOuNulo(int valor, string campo)
    {
        if (valor <= 0)
        {
            throw new ArgumentException($"O {campo} da casa não pode ser menor ou igual a zero");
        }
    }
}
