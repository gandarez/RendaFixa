using System;

namespace Gandarez.RendaFixa.IR.Tabela
{
    public static class IR
    {
        public static double Taxa(int dias)
        {
            if (dias <= 0)
                throw new ArgumentOutOfRangeException(nameof(dias), "Total de dias deve ser superior a zero");

            if (dias <= 180)
                return 22.5;
            if (dias <= 360)
                return 20;

            return dias <= 720 ? 17.5 : 15;
        }
    }
}
