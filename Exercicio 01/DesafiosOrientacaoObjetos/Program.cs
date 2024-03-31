using DesafiosOrientacaoObjetos.HerancaVsDelegacao.Delegacao.Modelos;
using DesafiosOrientacaoObjetos.HerancaVsDelegacao.Heranca.Modelos;
using DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.ClassesAbstratas;
using DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Interfaces.Validadores;
using DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Modelos;
using DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Modelos.Validadores;

class Program
{
    static void Main()
    {
        Console.WriteLine("Para iniciar escolha uma opção:");
        do
        {
            MostrarMenu();
            if (!int.TryParse(Console.ReadLine(), out int opcaoMenu) || (opcaoMenu != 0 && opcaoMenu != 1 && opcaoMenu != 2))
            {
                Console.WriteLine("Opção Inválida...");
                AguardarESair();
                return;
            }

            if(opcaoMenu == 0)
            {
                AguardarESair();
                return;
            }
            if (opcaoMenu == 1)
            {
                ExemploInterfaceVsClasseAbstrata();
            }
            else if (opcaoMenu == 2)
            {
                ExemploHerancaVsDelegacao();
            }
        } while (true);
    }
    static void ExemploInterfaceVsClasseAbstrata()
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
            MostrarOpcoesInterfaceVsClasseAbstrata();
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
        Console.WriteLine("");
        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }

    static void ExemploHerancaVsDelegacao()
    {
        while (true)
        {
            MostrarOpcoesHerancaVsDelegacao();
            string escolha = Console.ReadLine();
            int.TryParse(escolha, out int tipoOperacao);

            switch (tipoOperacao)
            {
                case 0:
                    Console.WriteLine("Saindo...");
                    return;
                case 1:
                    CadastrarGatoECachorro();
                    break;
                case 2:
                    MovimentarCarro();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
    static void CadastrarGatoECachorro()
    {
        Console.WriteLine("Exemplo de construção de classe utilizando Herança");
        while (true) 
        {
            MostrarOpcoesCadastroAnimal();
            string escolha = Console.ReadLine();
            int.TryParse(escolha, out int tipoOperacao); switch (tipoOperacao)
            {
                case 0:
                    Console.WriteLine("Saindo...");
                    return;
                case 1:
                    CadastrarCachorro();
                    break;
                case 2:
                    CadastrarGato();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } 
    }
    static void CadastrarCachorro()
    {
        Cachorro cachorro = new Cachorro();

        Console.WriteLine("Informe o nome do cachorro:");
        string nomeCachorro = Console.ReadLine();

        Console.WriteLine("Informe a raça do cachorro:");
        string racaCachorro = Console.ReadLine();

        cachorro.Nome = nomeCachorro;
        cachorro.Raca = racaCachorro;
        try
        {
            cachorro.CadastroValido();
            while (true) 
            {
                MostrarOpcoesCachorro();
                string escolha = Console.ReadLine();
                int.TryParse(escolha, out int tipoOperacao); switch (tipoOperacao)
                {
                    case 0:
                        Console.WriteLine("Saindo...");
                        return;
                    case 1:
                        cachorro.Comer();
                        if (!RealizarNovaOperacao())
                        {
                            return;
                        }
                        break;
                    case 2:
                        cachorro.Dormir();
                        if (!RealizarNovaOperacao())
                        {
                            return;
                        }
                        break;
                    case 3:
                        cachorro.Latir();
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
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro ao validar cadastro do cachorro : {ex.Message}");
            AguardarESair();
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Falha ao realizar validação do cadastro do cachorro. Erro: {ex.Message}");
            AguardarESair();
            return;
        }
    }
    static void CadastrarGato()
    {
        Gato gato = new Gato();

        Console.WriteLine("Informe o nome do gato:");
        string nomeGato = Console.ReadLine();

        Console.WriteLine("Informe a raça do gato:");
        string racaGato = Console.ReadLine();

        gato.Nome = nomeGato;
        gato.Raca = racaGato;
        try
        {
            gato.CadastroValido();
            while (true) 
            {
                MostrarOpcoesGato();
                string escolha = Console.ReadLine();
                int.TryParse(escolha, out int tipoOperacao); switch (tipoOperacao)
                {
                    case 0:
                        Console.WriteLine("Saindo...");
                        return;
                    case 1:
                        gato.Comer();
                        if (!RealizarNovaOperacao())
                        {
                            return;
                        }
                        break;
                    case 2:
                        gato.Dormir();
                        if (!RealizarNovaOperacao())
                        {
                            return;
                        }
                        break;
                    case 3:
                        gato.Miar();
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
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro ao validar cadastro do gato : {ex.Message}");
            AguardarESair();
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Falha ao realizar validação do cadastro do gato. Erro: {ex.Message}");
            AguardarESair();
            return;
        }
    }
    static void MovimentarCarro()
    {
        Console.WriteLine("Exemplo de construção de classe utilizando Delegação");
        Console.WriteLine("");
        Console.WriteLine("Pressione alguma tecla para ligar o carro!");
        Console.ReadKey();
        Carro carro = new Carro();
        carro.AcelerarCarro();
        Console.WriteLine("");
        Console.WriteLine("Agora pressione alguma tecla para desligar o carro!");
        Console.ReadKey();
        carro.DesligarCarro();
        Console.WriteLine("");
    }
    static void MostrarMenu()
    {
        Console.WriteLine("");
        Console.WriteLine("Menu Principal:");
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine("| 1 - Exemplo de Interface Vs Classe Abstrata (Movimentação de Conta bancária) |");
        Console.WriteLine("| 2 - Exemplo de Herança (Animais) Vs Delegação (Carro)                        |");
        Console.WriteLine("| 0 - Encerrar Aplicação                                                       |");
        Console.WriteLine("--------------------------------------------------------------------------------");
    }
    static void MostrarOpcoesInterfaceVsClasseAbstrata()
    {
        Console.WriteLine("");
        Console.WriteLine("Escolha uma opção de movimentação bancária:");
        Console.WriteLine("1 - Depositar");
        Console.WriteLine("2 - Sacar");
        Console.WriteLine("3 - Consultar Saldo da Conta");
        Console.WriteLine("0 - Sair");
    }
    static void MostrarOpcoesCadastroAnimal()
    {
        Console.WriteLine("");
        Console.WriteLine("Escolha uma opção para cadastrar um novo animal:");
        Console.WriteLine("1 - Cachorro");
        Console.WriteLine("2 - Gato");
        Console.WriteLine("0 - Sair");
    }
    static void MostrarOpcoesCachorro()
    {
        Console.WriteLine("");
        Console.WriteLine("Escolha uma opção para o cachorro fazer:");
        Console.WriteLine("1 - Comer");
        Console.WriteLine("2 - Dormir");
        Console.WriteLine("3 - Latir");
        Console.WriteLine("0 - Sair");
    }
    static void MostrarOpcoesGato()
    {
        Console.WriteLine("");
        Console.WriteLine("Escolha uma opção para o gato fazer:");
        Console.WriteLine("1 - Comer");
        Console.WriteLine("2 - Dormir");
        Console.WriteLine("3 - Miar");
        Console.WriteLine("0 - Sair");
    }
    static void MostrarOpcoesHerancaVsDelegacao()
    {
        Console.WriteLine("");
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Herança - Classe de Animais");
        Console.WriteLine("2 - Delegação - Classe de Carros");
        Console.WriteLine("0 - Sair");
    }
}