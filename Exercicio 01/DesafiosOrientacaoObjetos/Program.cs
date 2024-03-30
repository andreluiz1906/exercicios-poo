using DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.ClassesAbstratas;
using DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Interfaces.Validadores;
using DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Modelos;
using DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Modelos.Validadores;
using System.Transactions;


class Program
{
    static void Main()
    {
        Console.WriteLine("Olá!");
        Console.WriteLine("Vamos abrir uma conta para o cliente...");
        Console.WriteLine("Para iniciar, escolha um tipo de conta:");
        Console.WriteLine("1 - Conta Corrente");
        Console.WriteLine("2 - Conta Poupança");

        if (!int.TryParse(Console.ReadLine(), out int opcaoConta) || (opcaoConta != 1 && opcaoConta != 2))
        {
            Console.WriteLine("Opção Inválida...");
            AguardarESair();
            return;
        }

        Console.WriteLine("Agora informe o nome do cliente:");
        string nomeCliente = Console.ReadLine();

        Console.WriteLine("Digite o CPF do cliente:");
        string cpfCliente = Console.ReadLine();

        IValidador<string> validadorCPF = new ValidadorCPF();
        IValidador<Cliente> validadorCliente = new ValidadorCliente(validadorCPF);

        Cliente cliente = new Cliente(nomeCliente, cpfCliente, validadorCPF, validadorCliente);

        try
        {
            if (!cliente.ValidarCliente())
            {
                Console.WriteLine("Cadastro de cliente inválido...");
                AguardarESair();
                return;
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro ao validar cadastro de cliente : {ex.Message}");
            AguardarESair();
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Falha ao realizar validação dos dados cadastrais. Erro: {ex.Message}");
            AguardarESair();
            return;
        }

        Conta conta = opcaoConta == 1 ? new ContaCorrente() : new ContaPoupanca();
        conta.AbrirConta(cliente);

        while (true)
        {
            MostrarOpcoes();
            string escolha = Console.ReadLine();
            int.TryParse(escolha, out int tipoOperacao);

            switch (tipoOperacao)
            {
                case 0:
                    Console.WriteLine("Saindo...");
                    return;
                case 1:
                    RealizarOperacao(conta.Depositar);
                    if (!RealizarNovaOperacao())
                    {
                        return;
                    }
                    break;
                case 2:
                    RealizarOperacao(conta.Sacar);
                    if (!RealizarNovaOperacao())
                    {
                        return;
                    }
                    break;
                case 3:
                    conta.ConsultarSaldo(); 
                    if (!RealizarNovaOperacao())
                    {
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static void MostrarOpcoes()
    {
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Depositar");
        Console.WriteLine("2 - Sacar");
        Console.WriteLine("3 - Consultar Saldo da Conta");
        Console.WriteLine("0 - Sair");
    }
    static bool RealizarNovaOperacao()
    {
        Console.WriteLine("Deseja realizar uma nova operação?");
        Console.WriteLine("1 - Sim");
        Console.WriteLine("2 - Não");

        if (!int.TryParse(Console.ReadLine(), out int tipoOperacao) || (tipoOperacao != 1 && tipoOperacao != 2))
        {
            Console.WriteLine("Opção Inválida...");
            AguardarESair();
            return false;
        }

        if (tipoOperacao == 2)
        {
            Console.WriteLine("Obrigado pela utilização!");
            AguardarESair();
            return false;
        }
        return true;
    }
    static void RealizarOperacao(Action<decimal> operacao)
    {
        Console.WriteLine("Digite o valor da operação:");
        if (decimal.TryParse(Console.ReadLine(), out decimal valor))
        {
            try
            {
                operacao(valor);
                Console.WriteLine("Operação realizada com sucesso!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Valor inválido.");
        }        
    }

    static void AguardarESair()
    {
        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}