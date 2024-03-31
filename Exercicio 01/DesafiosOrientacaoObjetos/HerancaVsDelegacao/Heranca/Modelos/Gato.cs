using DesafiosOrientacaoObjetos.HerancaVsDelegacao.Heranca.ClassesAbstratas;

namespace DesafiosOrientacaoObjetos.HerancaVsDelegacao.Heranca.Modelos;

public class Gato : Animal
{
    public override void Comer()
    {
        Console.WriteLine($"O gato {Nome}, {Raca}, está comendo!");
    }

    public void Miar()
    {
        Console.WriteLine($"{Nome} fez Miau!");
    }
}
