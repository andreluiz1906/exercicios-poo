namespace DesafiosOrientacaoObjetos.HerancaVsDelegacao.Delegacao.Modelos;

public class Carro
{
    private Motor _motor;

    public Carro()
    {
        _motor = new Motor();
    }

    public void AcelerarCarro()
    {
        _motor.Ligar();
        Console.WriteLine("O carro está acelerando...");
    }

    public void DesligarCarro()
    {
        Console.WriteLine("O carro está freiando e será desligado...");
        _motor.Desligar();
    }
}

