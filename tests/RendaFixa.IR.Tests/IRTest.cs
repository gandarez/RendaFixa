using System;
using Xunit;

namespace Gandarez.RendaFixa.IR.Tests
{
    public class IRTest
    {
        [Fact]
        public void Prazo5DiasNegativo_Taxa_DeveRetornar_Exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>("dias", () => Tabela.IR.Taxa(-5));
        }

        [Fact]        
        public void Prazo0Dias_Taxa_DeveRetornar_Exception()
        {                                   
            Assert.Throws<ArgumentOutOfRangeException>("dias", () => Tabela.IR.Taxa(0));
        }

        [Fact]
        public void Prazo150Dias_Taxa_DeveRetornar_22_5()
        {            
            var actual = Tabela.IR.Taxa(150);

            Assert.Equal(22.5, actual);
        }

        [Fact]
        public void Prazo180Dias_Taxa_DeveRetornar_22_5()
        {            
            var actual = Tabela.IR.Taxa(180);

            Assert.Equal(22.5, actual);
        }

        [Fact]
        public void Prazo300Dias_Taxa_DeveRetornar_20()
        {            
            var actual = Tabela.IR.Taxa(300);            

            Assert.Equal(20, actual);
        }

        [Fact]
        public void Prazo360Dias_Taxa_DeveRetornar_20()
        {            
            var actual = Tabela.IR.Taxa(360);

            Assert.Equal(20, actual);
        }

        [Fact]
        public void Prazo700Dias_Taxa_DeveRetornar_17_5()
        {            
            var actual = Tabela.IR.Taxa(700);

            Assert.Equal(17.5, actual);
        }
        [Fact]
        public void Prazo720Dias_Taxa_DeveRetornar_17_5()
        {            
            var actual = Tabela.IR.Taxa(720);

            Assert.Equal(17.5, actual);
        }

        [Fact]
        public void Prazo1080Dias_Taxa_DeveRetornar_15()
        {
            var actual = Tabela.IR.Taxa(1080);

            Assert.Equal(15, actual);
        }
    }
}
