using System;

namespace Gandarez.RendaFixa.LCI
{
    public class LCIPreFixado
    {
        public decimal Rentabilidade(decimal precoCompra, int meses, double taxa, bool truncate = true)
        {
            /*
             *  .:: Fórmula ::.
             *  
             *  Rentabilidade=preCompra*((1+(taxa/100))^((meses/12)-1)*100)+1)
             * 
             */
            var taxaConvertida = (decimal)(Math.Pow(1 + taxa / 100, (double)meses / 12) - 1);
            var rentBruta = precoCompra  * (1 + taxaConvertida);
            
            return truncate ? Math.Truncate(rentBruta * 100 * 10000) / 10000 : rentBruta;
        }
    }
}
