using DesafiosOrientacaoObjetos.HerancaVsDelegacao.Heranca.ClassesAbstratas;

namespace DesafiosOrientacaoObjetos.HerancaVsDelegacao.Heranca.Modelos;

public class Cachorro : Animal
{
    public override void Comer()
    {
        Console.WriteLine($"O cachorro {Nome}, {Raca}, está comendo...");
    }

    public void Latir()
    {
        Console.WriteLine($"{Nome} fez Au au!");
    }
}