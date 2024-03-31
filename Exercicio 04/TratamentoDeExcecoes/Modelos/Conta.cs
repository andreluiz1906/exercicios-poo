namespace TratamentoDeExcecoes.Modelos;

public class Conta
{
    private double saldo;

    public Conta(double saldoInicial)
    {
        saldo = saldoInicial;
    }

    public void Debitar(double valor)
    {
        if (saldo < valor)
        {
            throw new SaldoInsuficienteException("Saldo insuficiente para realizar o débito.");
        }

        saldo -= valor;
    }

    public void Creditar(double valor)
    {
        saldo += valor;
    }

    public double ObterSaldo()
    {
        return saldo;
    }
}
