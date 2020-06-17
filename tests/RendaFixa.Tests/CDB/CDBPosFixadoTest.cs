using Gandarez.RendaFixa.CDB;
using Xunit;

namespace Gandarez.RendaFixa.Tests.CDB
{
    public class CDBPosFixadoTest
    {
        [Fact]
        public void Valor1000_Cdi13_75_Cdigarantido_80_500Dias_DeveRetornar_Pu_1226_92013703706()
        {
            var cdb = new CDBPosFixado();
            var actual = cdb.PU(1000, 13.75, 80, 500);

            Assert.Equal(1226.92013703706M, actual);
        }

        [Fact]
        public void Cdi13_75_DeveRetornar_CdiDiario_0_000511372261169374()
        {
            var cdb = new CDBPosFixado();
            var actual = cdb.CDIDiario(13.75);

            Assert.Equal(0.000511372261169374M, actual);
        }
    }
}