using System;
using System.Linq;

namespace Gandarez.RendaFixa.TD
{
    public class NTNF
    {
        /// <summary>
        /// Calcula o valor do Cupom na data do pagamento ou vencimento
        /// </summary>        
        /// <param name="resgate">Indica se o calculo devera considerar resgate</param>
        /// <param name="truncate">Truncar o resultado em 6 casas decimais</param>
        /// <returns>Valor do cupom</returns>
        public decimal Cupom(bool resgate = false, bool truncate = true)
        {
            /*
            *  .:: Fórmula ::.
            *  
            *  Cupom=1000*(1.1 ^ 0.5 -(fatorResgate))
            * 
            */
            var fatorResgate = resgate ? 0 : 1;
            var cupom = (decimal)(1000 * Math.Round(Math.Pow(1.1, 0.5) - fatorResgate, 8));

            return truncate ? Math.Truncate(cupom * 1000000) / 1000000 : cupom;
        }

        /// <summary>
        /// Calcula o PU
        /// </summary>
        /// <param name="taxa">Taxa de juros anual (padrão du/252 % aa)</param>
        /// <param name="dias">Total de dias uteis entre a data de pagamento ou liquidação (inclusive) e a data de vencimento (exclusive)</param>
        /// <param name="resgate">Indica se o calculo devera considerar resgate</param>
        /// <returns>Preço unitário</returns>
        public decimal PU(double taxa, int dias, bool resgate = false)
        {
            /*
           *  .:: Fórmula ::.
           *             
           *  pu=cupom/taxa^du/252
           * 
           */
            taxa = 1 + Math.Truncate(taxa * 10000) / 10000 / 100;
            var cupom = Cupom(resgate);
            var pu = Math.Round((double)cupom, 5) /
                     Math.Round(Math.Pow(taxa, (double)dias / 252), 9);

            return (decimal)Math.Truncate(pu * 1000000000) / 1000000000;
        }

        /// <summary>
        /// Calcula o PU
        /// </summary>
        /// <param name="taxa">Taxa de juros anual (padrão du/252 % aa)</param>
        /// <param name="dias">Quantidade de dias acumulado em cada pagamento</param>
        /// <param name="resgate">Indica se o calculo devera considerar resgate</param>
        /// <returns>Preço unitário</returns>
        public decimal PU(double taxa, int[] dias, bool resgate = false)
        {
            /*
           *  .:: Fórmula ::.
           *             
           *  pu=cupom/taxa^du/252 + cupom/taxa^du/252 + ... + resgate
           * 
           */
            var pu = dias.TakeWhile((i, i1) => i1 < dias.Length - 1).Sum(t => PU(taxa, t));

            if (resgate)
                pu += PU(taxa, dias[^1], true);

            return Math.Truncate(pu * 1000000000) / 1000000000;
        }        
    }
}