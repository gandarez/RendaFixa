using System;
using Xunit;
using Tabela = Gandarez.RendaFixa.IR.Tabela;

namespace Gandarez.RendaFixa.Tests.IR
{
    public class IRTest
    {
        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        public void IRTaxas_Exception(int prazo)
        {
            Assert.Throws<ArgumentOutOfRangeException>("dias", () => Tabela.IR.Taxa(prazo));
        }

        [Theory]
        [InlineData(150, 22.5)]
        [InlineData(180, 22.5)]
        [InlineData(300, 20)]
        [InlineData(360, 20)]
        [InlineData(700, 17.5)]
        [InlineData(720, 17.5)]
        [InlineData(1080, 15)]
        public void IRTaxas(int prazo, double taxa)
        {
            var actual = Tabela.IR.Taxa(prazo);

            Assert.Equal(taxa, actual);
        }
    }
}