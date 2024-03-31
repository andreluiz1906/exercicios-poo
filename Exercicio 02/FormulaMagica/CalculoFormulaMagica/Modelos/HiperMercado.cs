namespace CalculoFormulaMagica.Modelos;

public static class HiperMercado
{
    public static class Hi
    {
        //Criado uma classe apenas para simular a função de formulaMagica, de HiperMercado.Hi.formulaMagica(custo, validade);
        /*
         Simulação para porcentagem aplicada sobre o custo:
            * Produtos com validade menor que 07 dias então será aplicado 12,00%
            * Produtos com validade entre 07 e 15 dias então será aplicado 18,00%
            * Produtos com validade entre 15 e 30 dias então será aplicado 22,50%
            * Produtos com validade entre 30 e 45 dias então será aplicado 30,00%
            * Produtos com validade maior que 45 dias então será aplicado 35,00%
         */
        private static readonly Dictionary<(int, int), double> PorcentagensValidade = new Dictionary<(int, int), double>
        {
            { (0, 7), 0.12 },   // Menos de 7 dias: 12%
            { (7, 15), 0.18 },  // 7 a 15 dias: 18%
            { (15, 30), 0.225 },// 15 a 30 dias: 22.5%
            { (30, 45), 0.30 }, // 30 a 45 dias: 30%
            { (45, int.MaxValue), 0.35 } // Mais de 45 dias: 35%
        };
        private static double ObterPercentualPorValidade(int validade)
        {
            foreach (var intervalo in PorcentagensValidade)
            {
                if (validade >= intervalo.Key.Item1 && validade < intervalo.Key.Item2)
                {
                    return intervalo.Value;
                }
            }
            throw new ArgumentException("Intervalo de validade não encontrado.");
        }

        public static double formulaMagica(double custo, int validade)
        {
            double percentual = ObterPercentualPorValidade(validade);
            double fatorConversao = 1 + percentual;

            return custo * fatorConversao;
        }
    }
}

