using PlanejamentoEleitoral.Modelos;
using System.Net.Http.Headers;

class Program
{
    private static List<Casa> _casas = new List<Casa>();
    static void Main()
    {
        Console.WriteLine("Planejamento Eleitoral");
        GerarCasasDeExemplo();
        do
        {
            MostrarMenu();
            if (!int.TryParse(Console.ReadLine(), out int opcaoMenu) || !(opcaoMenu >= 0 && opcaoMenu <= 2))
            {
                Console.WriteLine("Opção Inválida...");
                AguardarESair();
            }

            if (opcaoMenu == 0)
            {
                AguardarESair();
            }
            else
            {
                if (opcaoMenu == 1)
                {
                    CadastrarNovoEndereco();
                }

                if (opcaoMenu == 2)
                {
                    GerarPlanejamento();
                }

                if (!RealizarNovaOperacao())
                {
                    return;
                }
            }
        } while (true);
    }

    static void GerarCasasDeExemplo()
    {
        _casas = new List<Casa>
        {
            new Casa(new Rua("04575-902", "Rua Geraldo Flausino Gomes"), 61, 125),
            new Casa(new Rua("89035-300", "Rua Theodoro Holtrup"), 1, 80),
            new Casa(new Rua("84900-000", "Rua das Pitangueiras"), 50, 2),
            new Casa(new Rua("04571-000", "Av. Engenheiro Luís Carlos Berrini"), 1294, 18),
            new Casa(new Rua("89035-400", "Rua Almirante Barroso"), 1060, 70)
        };
    }

    static void CadastrarNovoEndereco()
    {
        try
        {
            Console.WriteLine("");
            Console.WriteLine("Informe o CEP da rua");
            string cepRua = Console.ReadLine();

            Console.WriteLine("Informe o nome da rua");
            string nomeRua = Console.ReadLine();

            Console.WriteLine("Informe o número da casa");
            string numeroResidencia = Console.ReadLine();

            Console.WriteLine("Informe o total de eleitores da casa");
            string totalEleitoresResidencia = Console.ReadLine();

            int.TryParse(numeroResidencia, out int numeroCasa);
            int.TryParse(totalEleitoresResidencia, out int totalEleitores);

            Casa novoEndereco = new Casa(new Rua(cepRua, nomeRua), numeroCasa, totalEleitores);
            AdicionarEnderecoNaLista(novoEndereco);
            Console.WriteLine("Novo endereço cadastrado com sucesso!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro ao cadastrar novo endereço: {ex.Message}");
            AguardarESair();
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Falha ao realizar validação do cadastro do endereço. Erro: {ex.Message}");
            AguardarESair();
            return;
        }
    }
    static void AdicionarEnderecoNaLista(Casa novaCasa)
    {
        _casas.Add(novaCasa);
    }
    static List<Rua> ObterRuasOrdenadasPorEleitores(List<Casa> casas)
    {
        Dictionary<Rua, int> eleitoresPorRua = new Dictionary<Rua, int>();

        foreach (var casa in casas)
        {
            if (!eleitoresPorRua.ContainsKey(casa.ObterRua()))
            {
                eleitoresPorRua[casa.ObterRua()] = 0;
            }
            eleitoresPorRua[casa.ObterRua()] += casa.ObterTotalEleitores();
        }

        var ruasOrdenadas = eleitoresPorRua.OrderByDescending(kv => kv.Value)
                                            .Select(kv => kv.Key)
                                            .ToList();

        return ruasOrdenadas;
    }

    static void GerarPlanejamento()
    {
        List<Rua> ruas = ObterRuasOrdenadasPorEleitores(_casas);
        Console.WriteLine("");
        Console.WriteLine("Ordem de ruas para visitar:");
        foreach (var rua in ruas)
        {
            Console.WriteLine($"CEP: {rua.ObterCep()}, Nome: {rua.ObterNome()}");
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("");
        Console.WriteLine("Menu Principal:");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("| 1 - Cadastrar um novo endereço         |");
        Console.WriteLine("| 2 - Visualizar planejamento eleitoral  |");
        Console.WriteLine("| 0 - Encerrar Aplicação                 |");
        Console.WriteLine("------------------------------------------");
    }

    static void AguardarESair()
    {
        Console.WriteLine("");
        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
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
}