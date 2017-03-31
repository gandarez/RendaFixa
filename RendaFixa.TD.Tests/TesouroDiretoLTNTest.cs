using Xunit;

namespace Gandarez.RendaFixa.TD.Tests
{
    public class TesouroDiretoLTNTest
    {
        [Fact]
        public void Taxa11_60_515Dias_DeveRetornar_PU_799_081416()
        {
            var ltn = new LTN();
            var actual = ltn.PU(11.6, 515);

            Assert.Equal(799.081416M, actual);
        }

        [Fact]
        public void PU799_081416_515Dias_DeveRetornar_Taxa_11_6()
        {
            var ltn = new LTN();
            var actual = ltn.Taxa(799.081416, 515);

            Assert.Equal(11.6M, actual);
        }

        [Fact]
        public void PU803_97534_Taxa11_3367_512Dias_DeveRetornar_Taxa_11_3367()
        {
            var ltn = new LTN();
            var pu = ltn.PU(11.3367, 512);
            var actual = ltn.Taxa((double)pu, 512);

            Assert.Equal(11.3367M, actual);
        }        

        [Fact]
        public void PrecoCompra733_86_PrecoVenda874_61_DeveRetornar_RentabilidadeBruta_19_1794()
        {
            var ltn = new LTN();
            var actual = ltn.Rentabilidade(733.86M, 874.61M);

            Assert.Equal(19.1794M, actual);
        }

        [Fact]
        public void PrecoCompra733_86_PrecoVenda1000_755dias_DeveRetornar_Rentabilidade_10_88()
        {
            var ltn = new LTN();
            var actual = ltn.Rentabilidade(733.86M, 1000, 755);

            Assert.Equal(10.8804M, actual);
        }

        [Fact]
        public void PrecoCompra753_315323_PrecoVenda1000_532dias_DeveRetornar_Rentabilidade_14_36()
        {
            var ltn = new LTN();
            var actual = ltn.Rentabilidade(753.315323M, 1000, 532);

            Assert.Equal(14.36M, actual);
        }
    }
}
