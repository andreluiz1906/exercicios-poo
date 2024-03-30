using DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.ClassesAbstratas;

namespace DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Modelos;

public class ContaPoupanca : Conta
{
    public override void AbrirConta(Cliente cliente)
    {
        Titular = cliente;
        Console.WriteLine($"Conta Corrente aberta para o cliente {Titular.Nome}.");
    }

    public override void ConsultarSaldo()
    {
        Console.WriteLine($"Extrato da Conta Poupança do cliente {Titular.Nome}:");
        Console.WriteLine($"Saldo atual: {Saldo:C}");
    }
}
