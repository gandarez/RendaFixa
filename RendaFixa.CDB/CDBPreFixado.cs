using System;

namespace Gandarez.RendaFixa.CDB
{
    public class CDBPreFixado
    {
        /// <summary>
        /// Calcula preço unitário
        /// </summary>
        /// <param name="valor">Valor de aplicação inicial</param>
        /// <param name="taxa">Taxa acordada</param>
        /// <param name="dias">Quantidade de dias até o vencimento</param>
        /// <returns>Preço unitário</returns>
        public decimal PU(double valor, double taxa, int dias)
        {
            taxa = taxa / 100 + 1;
            return (decimal)(valor * Math.Pow(taxa, (double)dias / 252));
        }
    }
}
