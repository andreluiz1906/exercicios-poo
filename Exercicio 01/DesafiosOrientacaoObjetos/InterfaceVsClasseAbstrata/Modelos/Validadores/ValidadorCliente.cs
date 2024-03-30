using DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Interfaces.Validadores;

namespace DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Modelos.Validadores;

public class ValidadorCliente : IValidador<Cliente>
{
    private readonly IValidador<string> _validadorCPF;

    public ValidadorCliente(IValidador<string> validadorCPF)
    {
        _validadorCPF = validadorCPF;
    }

    public bool Validar(Cliente cliente)
    {
        if (cliente == null)
        {
            throw new ArgumentNullException(nameof(cliente));
        }

        if (string.IsNullOrWhiteSpace(cliente.Nome))
        {
            throw new ArgumentException("O nome não pode ser vazio ou em branco.", nameof(cliente.Nome));
        }

        if (!_validadorCPF.Validar(cliente.CPF))
        {
            throw new ArgumentException("CPF inválido.", nameof(cliente.CPF));
        }

        return true;
    }
}
