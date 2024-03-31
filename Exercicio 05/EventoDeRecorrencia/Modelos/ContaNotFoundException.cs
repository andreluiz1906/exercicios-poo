namespace EventoDeRecorrencia.Modelos;

public class ContaNotFoundException : Exception
{
    public ContaNotFoundException() { }

    public ContaNotFoundException(string message) : base(message) { }

    public ContaNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}