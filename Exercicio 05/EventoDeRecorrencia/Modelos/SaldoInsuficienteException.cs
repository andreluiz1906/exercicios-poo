namespace EventoDeRecorrencia.Modelos;

public class SaldoInsuficienteException : Exception
{
    public SaldoInsuficienteException() : base("Saldo insuficiente para realizar a operação.")
    {
    }

    public SaldoInsuficienteException(string message) : base(message)
    {
    }

    public SaldoInsuficienteException(string message, Exception innerException) : base(message, innerException)
    {
    }
}