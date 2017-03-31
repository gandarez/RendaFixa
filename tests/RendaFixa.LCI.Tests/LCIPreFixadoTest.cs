using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandarez.RendaFixa.LCI;
using Xunit;

namespace RendaFixa.LCI.Tests
{
    public class LCIPreFixadoTest
    {
        [Fact]
        public void Valor1000_Taxa14_3Meses_DeveRetornar_Rentabilidade_1035086_7806()
        {
            var lci = new LCIPreFixado();
            var actual = lci.Rentabilidade(10000, 14, 3);

            Assert.Equal(1035086.7806M, actual);
        }
    }
}
