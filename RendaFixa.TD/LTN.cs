using System;

namespace Gandarez.RendaFixa.TD
{
    public class LTN
    {
        /// <summary>
        /// Calcula o preço unitário
        /// </summary>        
        /// <param name="taxa">Taxa de juros anual (padrão du/252 % aa)</param>
        /// <param name="dias">Total de dias uteis entre a data de liquidação (inclusive) e a data de vencimento (exclusive)</param>
        /// <returns>Preço unitário</returns>
        public decimal PU(double taxa, int dias)
        {
            /*
             *  .:: Fórmula ::.
             *  
             *  PU=1000/(1+taxa)^(du/252) 
             * 
             */
            taxa = 1 + Math.Truncate(taxa * 10000) / 10000 / 100;
            var pu = 1000 / Math.Pow(taxa, (double)dias / 252);
            return (decimal)(Math.Truncate(pu * 1000000) / 1000000);
        }

        /// <summary>
        /// Calcula taxa de juros anual
        /// </summary>
        /// <param name="pu">Preço unitário</param>
        /// <param name="dias">Total de dias uteis entre a data de liquidação (inclusive) e a data de vencimento (exclusive)</param>
        /// <returns>Taxa de juros anual</returns>
        public decimal Taxa(double pu, int dias)
        {
            /*
             *  .:: Fórmula ::.
             *  
             *  Taxa=(1000/pu)^(252/du)-1
             * 
             */
            var taxa = (Math.Pow(1000 / pu, 252 / (double)dias) - 1) * 100;
            return (decimal)(Math.Truncate(taxa * 10000) / 10000);
        }

        /// <summary>
        /// Calcula a rentabilidade bruta da aplicação
        /// </summary>
        /// <param name="precoCompra">Preço de compra</param>
        /// <param name="precoVenda">Preço de venda</param>
        /// <param name="truncate">Truncar o resultado em 4 casas decimais</param>
        /// <returns>Rentabilidade bruta da aplicação</returns>
        public decimal Rentabilidade(decimal precoCompra, decimal precoVenda, bool truncate = true)
        {
            /*
             *  .:: Fórmula ::.
             *  
             *  Rentabilidade=precoVenda/precoCompra-1
             * 
             */
            var rentBruta = precoVenda / precoCompra - 1;
            return truncate ? Math.Truncate(rentBruta * 100 * 10000) / 10000 : rentBruta;
        }

        /// <summary>
        /// Calcula a taxa de rentabilidade equivalente ao ano
        /// </summary>
        /// <param name="precoCompra">Preço de compra</param>
        /// <param name="precoVenda">Preço de venda</param>
        /// <param name="dias">Total de dias uteis</param>
        /// <returns>Taxa de rentabilidade %aa</returns>
        public decimal Rentabilidade(decimal precoCompra, decimal precoVenda, int dias)
        {
            /*
             *  .:: Fórmula ::.
             *  
             *  Rentabilidade=1+(precoVenda/precoCompra-1)^252/dias
             * 
             */
            var rentBruta = Rentabilidade(precoCompra, precoVenda, false);
            return (decimal)Math.Truncate((Math.Pow((double)(1 + rentBruta), 252 / (double)dias) - 1) * 100 * 10000) / 10000;
        }
    }
}
