namespace EventoDeRecorrencia.Modelos;

public class Conta
{
    private long id;
    private double saldo;

    public Conta(long id, double saldoInicial)
    {
        this.id = id;
        this.saldo = saldoInicial;
    }

    public void credite(double valor)
    {
        // Verifica se o valor é válido
        if (valor <= 0)
        {
            throw new ArgumentException("O valor a ser creditado deve ser maior que zero.");
        }

        // Realiza o crédito na conta
        saldo += valor;
    }

    public void debite(double valor)
    {
        // Verifica se há saldo suficiente para debitar
        if (valor > saldo)
        {
            throw new SaldoInsuficienteException();
        }

        // Realiza o débito na conta
        saldo -= valor;
    }
    public bool podeDebitar(double valor)
    {
        return saldo >= valor;
    }
    public double Saldo
    {
        get { return saldo; }
    }
}

