using DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Interfaces;
using DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Modelos;

namespace DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.ClassesAbstratas;

public abstract class Conta : IMovimentacaoConta
{
    public Cliente Titular { get; protected set; }
    public decimal Saldo { get; protected set; }

    public abstract void AbrirConta(Cliente cliente);
    public abstract void ConsultarSaldo();

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do depósito deve ser maior que zero.", nameof(valor));
        }

        Saldo += valor;
        Console.WriteLine($"Depósito de {valor:C} realizado. Novo saldo: {Saldo:C}");
    }

    public void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor de saque deve ser maior que zero.", nameof(valor));
        }

        if (valor > Saldo)
        {
            throw new ArgumentException("Saldo insuficiente.", nameof(valor));
        }

        Saldo -= valor;
        Console.WriteLine($"Saque de {valor:C} realizado. Novo saldo: {Saldo:C}");
    }
}