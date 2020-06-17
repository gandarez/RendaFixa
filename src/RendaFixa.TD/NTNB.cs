using System;
using System.Linq;

namespace Gandarez.RendaFixa.TD
{
    public class NTNB
    {
        /// <summary>
        /// Calcula o valor do cupom na data do pagamento ou vencimento
        /// </summary>
        /// <param name="truncate">Truncar o resultado em 6 casas decimais</param>
        /// <returns>Valor do cupom</returns>
        public decimal Cupom(bool truncate = true)
        {
            /*
            *  .:: Fórmula ::.
            *  
            *  Cupom=100*(1.06 ^ 0.5 -1)
            * 
            */
            var cupom = (decimal)Math.Round(Math.Pow(1.06, 0.5) - 1, 8);

            return truncate ? Math.Truncate(cupom * 1000000) / 1000000 : cupom;
        }

        /// <summary>
        /// Calcula cotação
        /// </summary>        
        /// <param name="taxa">Taxa interna de retorno (padrão du/252 % aa)</param>
        /// <param name="dias">Total de dias uteis entre a data de liquidação (inclusive) e a data de vencimento (exclusive)</param>
        /// <param name="resgate">Indica se o calculo devera considerar resgate</param>
        /// <param name="truncate">Truncar o resultado em 9 casas decimais</param>
        /// <returns>Valor da cotação</returns>
        public decimal Cotacao(double taxa, int dias, bool resgate = false, bool truncate = true)
        {
            /*
            *  .:: Fórmula ::.
            *  
            *  cotacao=cupom/taxa^du/252
            * 
            */
            taxa = 1 + Math.Truncate(taxa * 10000) / 10000 / 100;
            var cupom = resgate ? 1 : Cupom(false);
            var cotacao = (decimal) (Math.Round((double) cupom, 6)/
                                     Math.Round(Math.Pow(taxa, (double) dias/252), 10));
                        
            return truncate ? Math.Truncate(cotacao * 1000000000) / 1000000000 : cotacao;
        }

        /// <summary>
        /// Calcula cotação
        /// </summary>
        /// <param name="taxa">Taxa interna de retorno (padrão du/252 % aa)</param>
        /// <param name="dias">Quantidade de dias acumulado em cada pagamento</param>
        /// <param name="resgate">Indica se o calculo devera considerar resgate</param>
        /// <returns></returns>
        public decimal Cotacao(double taxa, int[] dias, bool resgate = false)
        {
            /*
            *  .:: Fórmula ::.
            *             
            *  cotacao=cupom/taxa^du/252 + cupom/taxa^du/252 + ... + resgate
            * 
            */
            var cotacao = dias.Sum(t => Cotacao(taxa, t));

            if (resgate)
                cotacao += Cotacao(taxa, dias[^1], true);

            return cotacao;
        }
        
        /// <summary>
        /// Calcula o PU
        /// </summary>
        /// <param name="vna">Valor nominal atualizado</param>
        /// <param name="cotacao">Valor da cotação</param>
        /// <param name="truncate">Truncar o resultado em 6 casas decimais</param>
        /// <returns>Preço unitário</returns>
        public decimal PU(double vna, double cotacao, bool truncate = true)
        {
            /*
            *  .:: Fórmula ::.
            *             
            *  vna*cotacao
            * 
            */            
            cotacao = Math.Truncate(cotacao * 10000) / 10000 / 100;
            var pu = (decimal)(vna * cotacao);
            
            return truncate ? Math.Truncate(pu * 1000000) / 1000000 : pu;
        }

        /// <summary>
        /// Calcula o valor presente
        /// </summary>
        /// <param name="valor">Valor futuro</param>
        /// <param name="taxa">Taxa aplicada</param>
        /// <param name="dias">Total de dias uteis</param>
        /// <param name="truncate">Truncar o resultado em 6 casas decimais</param>
        /// <returns>Valor presente</returns>
        public decimal ValorPresente(double valor, double taxa, int dias, bool truncate = true)
        {
            /*
            *  .:: Fórmula ::.
            *             
            *  vp=valor/taxa^dias/252
            * 
            */
            taxa = taxa / 100 + 1;
            var vp = (decimal)(valor / Math.Pow(taxa, (double)dias / 252));
            
            return truncate ? Math.Truncate(vp * 1000000) / 1000000 : vp;
        }

        /// <summary>
        /// Calcula VNA nominal atualizado apos dia 15 e antes da divulgacao do proximo IPCA
        /// </summary>
        /// <param name="vna">VNA corrigido ate a data</param>
        /// <param name="ipca">IPCA projetado</param>
        /// <param name="dias">Total de dias entre os indices do IPCA</param>
        /// <param name="dias2">Quantidade de dias desde o ultimo IPCA</param>
        /// <returns>Valor nominal atualizado</returns>
        public decimal VNA(double vna, double ipca, int dias, int dias2)
        {
            /*
            *  .:: Fórmula ::.
            *             
            *  vna=vna*ipca^(dias2/dias)
            * 
            */           
            ipca = ipca / 100 + 1;
            
            return (decimal)(vna * Math.Pow(ipca, (double)dias2 / dias));
        }
    }
}