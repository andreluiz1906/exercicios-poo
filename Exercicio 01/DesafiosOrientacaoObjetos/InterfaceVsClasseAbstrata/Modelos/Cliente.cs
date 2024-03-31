using DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Interfaces.Validadores;

namespace DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Modelos;

public class Cliente
{
    public string Nome { get; set; }
    public string CPF { get; set; }

    private readonly IValidador<string> _validadorCPF;
    private readonly IValidador<Cliente> _validadorCliente;

    public Cliente(string nome, string cpf, IValidador<string> validadorCPF, IValidador<Cliente> validadorCliente)
    {
        Nome = nome;
        CPF = cpf;
        _validadorCPF = validadorCPF;
        _validadorCliente = validadorCliente;
    }

    public bool ValidarCliente()
    {
        return _validadorCliente.Validar(this);
    }
}
