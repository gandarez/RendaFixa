using System;

namespace Gandarez.RendaFixa.TD
{
    public class LFT
    {
        /// <summary>
        /// Calcula a cotação
        /// </summary>
        /// <param name="taxa">Taxa (ágio ou deságio) de juros anual (padrão du/252 % aa)</param>
        /// <param name="dias">Total de dias uteis entre a data de liquidação (inclusive) e a data de vencimento (exclusive)</param>
        /// <returns>Cotação</returns>
        public decimal Cotacao(double taxa, int dias)
        {
            /*
             *  .:: Fórmula ::.
             *  
             *  Cotacao=100/(1+taxa)^du/252
             * 
             */
            taxa = 1 + Math.Truncate(taxa * 10000) / 10000 / 100;
            return (decimal)Math.Truncate(100 / Math.Pow(taxa, (double)dias / 252) * 10000) / 10000;
        }

        /// <summary>
        /// Calcula o PU
        /// </summary>
        /// <param name="vna">VNA projetado na data de liquidação</param>
        /// <param name="cotacao">Valor da cotação</param>
        /// <returns>Preço unitário</returns>
        public decimal PU(decimal vna, decimal cotacao)
        {
            /*
             *  .:: Fórmula ::.
             *  
             *  PU=vna*cotacao
             * 
             */
            cotacao = Math.Truncate(cotacao * 10000) / 10000 / 100;            
            return Math.Truncate(cotacao * (Math.Truncate(vna * 1000000) / 1000000) * 1000000) / 1000000;
        }

        /// <summary>
        /// Calcula o VNA projetado
        /// </summary>        
        /// <param name="selic">Índice Selic acumulado entre a data 01/07/2000 e a data de compra</param>
        /// <returns>VNA projetado</returns>
        public decimal VNA(decimal selic)
        {
            /*
             *  .:: Fórmula ::.
             *  
             *  VNA=1000*selic
             * 
             */
            return Math.Truncate(1000 * Math.Round(selic, 16) * 1000000) / 1000000;
        }

        /// <summary>
        /// Calcula o VNA projetado
        /// </summary>
        /// <param name="vna">VNA projetado</param>
        /// <param name="taxas">Taxa de cada período</param>
        /// <returns>VNA projetado</returns>
        public decimal VNA(decimal vna, decimal[] taxas)
        {
            /*
             *  .:: Fórmula ::.
             *  
             *  VNA=(vna*taxa^1/252) + (vna*taxa^1/252) + ...
             * 
             */
            var vnaRet = (double)vna;

            for (var i = 1; i <= taxas.Length; i++)
            {
                var taxa = 1 + taxas[i - 1] / 100;
                vnaRet = vnaRet * Math.Pow((double)taxa, (double)1 / 252);
            }

            return (decimal)Math.Truncate(vnaRet * 1000000) / 1000000;
        }        
    }
}