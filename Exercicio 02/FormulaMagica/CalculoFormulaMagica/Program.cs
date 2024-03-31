using CalculoFormulaMagica.Modelos;
class Program
{
    static void Main()
    {
        Console.WriteLine("Bem-vindo ao cálculo do preço de venda utilizando a biblioteca HiperMercado");

        MostrarMenu();
        if (!int.TryParse(Console.ReadLine(), out int opcaoMenu) || (opcaoMenu != 0 && opcaoMenu != 1))
        {
            Console.WriteLine("Opção Inválida...");
            AguardarESair();
        }

        if (opcaoMenu == 0)
        {
            AguardarESair();
        }

        if (opcaoMenu == 1)
        {
            ExemploCadastroItem();
        }
    }

    static void AguardarESair()
    {
        Console.WriteLine("");  
        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }
    static void MostrarMenu()
    {
        Console.WriteLine("");
        Console.WriteLine("Menu Principal:");
        Console.WriteLine("----------------------------");
        Console.WriteLine("| 1 - Cadastrar um item    |");
        Console.WriteLine("| 0 - Encerrar Aplicação   |");
        Console.WriteLine("----------------------------");
    }
    static bool RealizarNovaOperacao()
    {
        Console.WriteLine("Deseja cadastrar um novo item?");
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

    static Item CadastrarItem()
    {
        Console.WriteLine("Informe o nome do item:");
        string nomeItem = Console.ReadLine();

        Console.WriteLine("Informe o valor de custo do item:");
        string custoItem = Console.ReadLine();

        Console.WriteLine("Informe a validade em dias para o item:");
        string validadeItem = Console.ReadLine();

        if (!double.TryParse(custoItem, out double valorCusto))
        {
            throw new ArgumentException("Formato inválido para custo do item");
        }

        if (!int.TryParse(validadeItem, out int diasValidade))
        {
            throw new ArgumentException("Formato inválido para dias de validade do item");
        }

        return new Item(nomeItem, valorCusto, diasValidade);
    }
    static void CalcularValorVenda(Item item)
    {
        double valorVenda = CalculadorPreco.CalcularPreco(item);

        item.AtualizarValorVenda(valorVenda);
    }
    static void ExibirInformacoesItem(Item item)
    {
        Console.WriteLine("");
        Console.WriteLine($"Nome do item: {item.ObterNome()}");
        Console.WriteLine($"Validade do item: {item.ObterValidade()} dia(s)");
        Console.WriteLine($"Valor de custo: {item.ObterCusto().ToString("C")}");
        Console.WriteLine($"Valor de venda: {item.ObterValorVenda().ToString("C")}");
    }
    static void ExemploCadastroItem()
    {
        try
        {
            while (true)
            {
                Item itemCadastrado = CadastrarItem();

                CalcularValorVenda(itemCadastrado);
                ExibirInformacoesItem(itemCadastrado);
                if (!RealizarNovaOperacao())
                {
                    return;
                }
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro ao validar cadastro do item : {ex.Message}");
            AguardarESair();
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Falha ao realizar validação do cadastro do item. Erro: {ex.Message}");
            AguardarESair();
            return;
        }
    }
}