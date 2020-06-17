using Gandarez.RendaFixa.TD;
using Xunit;

namespace Gandarez.RendaFixa.Tests.TD
{
    public class TesouroDiretoNTNBTest
    {
        [Fact]
        public void Cupom_DeveRetornar_Cupom_0_029563()
        {
            var ntnb = new NTNB();
            var actual = ntnb.Cupom();

            Assert.Equal(0.029563M, actual);
        }

        [Fact]
        public void CondicaoResgate_Cupom_DeveRetornar_Cupom_0_02956301()
        {
            var ntnb = new NTNB();
            var actual = ntnb.Cupom(false);

            Assert.Equal(0.02956301M, actual);
        }        

        [Fact]
        public void Taxa5_32_91Dias_DeveRetornar_Cotacao_0_0290148()
        {
            var ntnb = new NTNB();
            var actual = ntnb.Cotacao(5.32, 91);

            Assert.Equal(0.0290148M, actual);
        }

        [Fact]
        public void Taxa5_32_1347Dias_DeveRetornar_Cotacao_0_022409008()
        {
            var ntnb = new NTNB();
            var actual = ntnb.Cotacao(5.32, 1347);

            Assert.Equal(0.022409008M, actual);
        }


        [Fact]
        public void Taxa6_5_106Dias_CondicaoResgate_DeveRetornar_Cotacao_0_973858367()
        {
            var ntnb = new NTNB();
            var actual = ntnb.Cotacao(6.5, 106, true);

            Assert.Equal(0.973858367M, actual);
        }

        [Fact]
        public void Taxa6_5_106Dias_CondicaoResgate_SemTruncar_DeveRetornar_Cotacao_0_97385836702506()
        {
            var ntnb = new NTNB();
            var actual = ntnb.Cotacao(6.5, 106, true, false);

            Assert.Equal(0.97385836702506M, actual);
        }

        [Fact]
        public void Taxa6_5_106Dias_SemCondicaoResgate_SemTruncar_DeveRetornar_Cotacao_0_0287901749043618()
        {
            var ntnb = new NTNB();
            var actual = ntnb.Cotacao(6.5, 106, false, false);

            Assert.Equal(0.0287901749043618M, actual);
        }

        [Fact]
        public void Taxa5_32_DiversosDias_CondicaoResgate_DeveRetornar_Cotacao_1_039339623()
        {
            var ntnb = new NTNB();
            var actual = ntnb.Cotacao(5.32, new[] { 91, 219, 341, 472, 593, 724, 846, 973, 1097, 1224, 1347 }, true);
                        
            Assert.Equal(1.039339623M, actual);
        }

        [Fact]
        public void Taxa5_32_DiversosDias_SemCondicaoResgate_DeveRetornar_Cotacao_0_281331003()
        {
            var ntnb = new NTNB();
            var actual = ntnb.Cotacao(5.32, new[] { 91, 219, 341, 472, 593, 724, 846, 973, 1097, 1224, 1347 });

            Assert.Equal(0.281331003M, actual);
        }

        [Fact]
        public void Vna1728_461136_Cotacao97_0813_DeveRetornar_Pu_1678_012540()
        {
            var ntnb = new NTNB();
            var actual = ntnb.PU(1728.461136, 97.0813);

            Assert.Equal(1678.012540M, actual);
        }

        [Fact]
        public void Vna1728_461136_Cotacao97_0813_SemTruncar_DeveRetornar_Pu_1678_01254082357()
        {
            var ntnb = new NTNB();
            var actual = ntnb.PU(1728.461136, 97.0813, false);

            Assert.Equal(1678.01254082357M, actual);
        }

        [Fact]
        public void Vna2950_Ipca0_39_TotalDias21_1DiaDesejado_DeveRetornar_Vna_2950_54684226885()
        {
            var ntnb = new NTNB();
            var actual = ntnb.VNA(2950, 0.39, 21, 1);

            Assert.Equal(2950.54684226885M, actual);
        }

        [Fact]
        public void Vna2950_Ipca0_5_TotalDias21_17DiasDesejados_DeveRetornar_Vna_2961_93480150027()
        {
            var ntnb = new NTNB();
            var actual = ntnb.VNA(2950, 0.5, 21, 17);

            Assert.Equal(2961.93480150027M, actual);
        }

        [Fact]
        public void ValorPresente102_956301_Taxa6_1475_1927Dias_DeveRetornar_Vp_65_241726()
        {
            var ntnb = new NTNB();
            var actual = ntnb.ValorPresente(102.956301, 6.1475, 1927);

            Assert.Equal(65.241726M, actual);
        }

        [Fact]
        public void ValorPresente2_956301_Taxa6_1475_1800Dias_DeveRetornar_Vp_1_930540()
        {
            var ntnb = new NTNB();
            var actual = ntnb.ValorPresente(2.956301, 6.1475, 1800);

            Assert.Equal(1.930540M, actual);
        }

        [Fact]
        public void ValorPresente2_956301_Taxa6_1475_1800Dias_SemTruncar_DeveRetornar_Vp_1_9305402652764()
        {
            var ntnb = new NTNB();
            var actual = ntnb.ValorPresente(2.956301, 6.1475, 1800, false);

            Assert.Equal(1.9305402652764M, actual);
        }
    }
}