using System;

namespace Gandarez.RendaFixa.CDB
{
    public class CDBPosFixado
    {
        /// <summary>
        /// Calcula preço unitário
        /// </summary>
        /// <param name="valor">Valor de aplicação inicial</param>
        /// <param name="cdi">Taxa CDI</param>
        /// <param name="cdiGarantido">Porcentagem do CDI garantido</param>
        /// <param name="dias">Quantidade de dias até o vencimento</param>
        /// <returns>Preço unitário</returns>
        public decimal PU(double valor, double cdi, double cdiGarantido, int dias)
        {            
            cdiGarantido = cdiGarantido / 100;
            var pu = valor;

            for (var i = 0; i < dias; i++)
            {
                pu += pu * ((double)CDIDiario(cdi) * cdiGarantido);
            }

            return (decimal)pu;
        }

        public decimal CDIDiario(double cdi)
        {
            cdi = cdi / 100 + 1;
            return (decimal)(Math.Pow(cdi, (double)1 / 252) - 1);
        }
    }
}