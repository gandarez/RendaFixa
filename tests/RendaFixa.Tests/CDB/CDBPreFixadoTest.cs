using Gandarez.RendaFixa.CDB;
using Xunit;

namespace Gandarez.RendaFixa.Tests.CDB
{
    public class CDBPreFixadoTest
    {
        [Fact]
        public void Valor1000_Taxa12_350Dias_DeveRetornar_Pu_11704_6481982438()
        {
            var cdb = new CDBPreFixado();
            var actual = cdb.PU(10000, 12, 350);

            Assert.Equal(11704.6481982438M, actual);
        }
    }
}