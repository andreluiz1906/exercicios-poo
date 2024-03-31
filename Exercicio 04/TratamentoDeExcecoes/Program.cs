using TratamentoDeExcecoes.Modelos;

class Program
{
    static void Main()
    {
        Console.WriteLine("Exemplo de tratamento de exceções...");
        try
        {
            Console.WriteLine("Operação: Divisão por 0");
            Console.WriteLine("10 / 0");

            int resultado = Dividir(10, 0);
            Console.WriteLine($"Resultado: {resultado}");
        }
        catch (DivisaoPorZeroException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("");
        }

        try
        {
            Console.WriteLine("Operação: Debitar saldo maior que o disponível");
            Console.WriteLine("Saldo Atual: R$ 100,00");
            Console.WriteLine("Saldo Debitar: R$ 150,00");

            Conta conta = new Conta(100.0);
            Console.WriteLine($"Saldo atual: {conta.ObterSaldo()}");

            conta.Debitar(150.0);
        }
        catch (SaldoInsuficienteException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("");
        }

        try
        {
            Console.WriteLine("Operação: Validação de Idade com valor menor que 0");
            Console.WriteLine("Idade: -5 anos");
            ValidarIdade(-5);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("");
        }

        try
        {
            Console.WriteLine("Operação: Validação de nome vazio ou nulo");
            Console.WriteLine("Nome: null");
            ValidarNome(null);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("");
        }

        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }

    static int Dividir(int dividendo, int divisor)
    {
        if (divisor == 0)
        {
            throw new DivisaoPorZeroException("Não é possível dividir por zero.");
        }
        return dividendo / divisor;
    }

    static void ValidarIdade(int idade)
    {
        if (idade < 0)
        {
            throw new ArgumentException("A idade não pode ser negativa.");
        }
    }

    static void ValidarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentNullException(nameof(nome), "O nome não pode ser nulo ou vazio.");
        }
    }
}