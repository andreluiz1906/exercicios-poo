using EventoDeRecorrencia.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace EventoDeRecorrencia.Data;

public class ContaDAO
{
    public void debitar(long idConta, double valor)
    {
        using (var transaction = new TransactionScope())
        {
            try
            {
                // Iniciar transação do banco de dados
                using (var dbContext = new ContaContext(new DbContextOptions<ContaContext>()))
                {
                    // Obter a conta dentro da transação
                    //Conta conta = dbContext.Contas.FirstOrDefault(c => c.Id == idConta);
                    Conta conta = new Conta(1, 0);
                    if (conta == null)
                    {
                        throw new ContaNotFoundException();
                    }

                    // Lock na conta para evitar condições de corrida
                    lock (conta)
                    {
                        if (conta.podeDebitar(valor))
                        {
                            conta.debite(valor);
                            dbContext.SaveChanges(); // Salvar alterações no banco de dados dentro da transação
                        }
                        else
                        {
                            throw new SaldoInsuficienteException();
                        }
                    }
                }

                // Commit da transação do banco de dados
                transaction.Complete();
            }
            catch (Exception ex)
            {
                // Rollback da transação em caso de exceção
                transaction.Dispose();
                throw ex;
            }
        }
    }

}
