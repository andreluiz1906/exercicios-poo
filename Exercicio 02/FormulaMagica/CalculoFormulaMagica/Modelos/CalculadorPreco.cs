namespace CalculoFormulaMagica.Modelos;

public class CalculadorPreco
{
    public static double CalcularPreco(Item item)
    {
        return HiperMercado.Hi.formulaMagica(item.ObterCusto(), item.ObterValidade());
    }
}