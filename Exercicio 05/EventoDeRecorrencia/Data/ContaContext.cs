using EventoDeRecorrencia.Modelos;
using Microsoft.EntityFrameworkCore;

namespace EventoDeRecorrencia.Data;

public class ContaContext : DbContext
{
    public ContaContext(DbContextOptions<ContaContext> options) : base(options)
    {
    }

    public DbSet<Conta> Contas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conta>().HasData(
            new Conta(1, 1000.00),
            new Conta(2, 500.00),
            new Conta(3, 1500.00)
        );
    }
}