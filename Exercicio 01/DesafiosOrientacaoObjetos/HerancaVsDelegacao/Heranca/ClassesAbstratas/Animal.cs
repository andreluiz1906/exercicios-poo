using DesafiosOrientacaoObjetos.InterfaceVsClasseAbstrata.Modelos;

namespace DesafiosOrientacaoObjetos.HerancaVsDelegacao.Heranca.ClassesAbstratas;

public abstract class Animal
{
    public string Nome { get; set; }
    public string Raca { get; set; }

    public abstract void Comer();

    public virtual void Dormir()
    {
        Console.WriteLine("O animal está dormindo...");
    }

    public virtual void CadastroValido()
    {
        if (string.IsNullOrWhiteSpace(Nome))
        {
            throw new ArgumentException("O nome não pode ser vazio ou em branco.", nameof(Nome));
        }

        if (string.IsNullOrWhiteSpace(Raca))
        {
            throw new ArgumentException("A raça não pode ser vazio ou em branco.", nameof(Raca));
        }
    }
}
