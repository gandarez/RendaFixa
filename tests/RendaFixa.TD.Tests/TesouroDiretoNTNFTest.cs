using Xunit;

namespace Gandarez.RendaFixa.TD.Tests
{
    public class TesouroDiretoNTNFTest
    {
        [Fact]
        public void Taxa11_60_2dias_DeveRetornar_Pu_48_766354121()
        {
            var ntnf = new NTNF();
            var actual = ntnf.PU(11.6, 2);

            Assert.Equal(48.766354121M, actual);
        }

        [Fact]
        public void Taxa13_66_28dias_DeveRetornar_Pu_48_119371631()
        {
            var ntnf = new NTNF();
            var actual = ntnf.PU(13.66, 28);

            Assert.Equal(48.119371631M, actual);
        }

        [Fact]
        public void Taxa13_66_1036dias_DeveRetornar_Pu_28_832967359()
        {
            var ntnf = new NTNF();
            var actual = ntnf.PU(13.66, 1036);

            Assert.Equal(28.832967359M, actual);
        }

        [Fact]
        public void Taxa13_66_1285dias_DeveRetornar_Pu_25_40643236()
        {
            var ntnf = new NTNF();
            var actual = ntnf.PU(13.66, 1285);

            Assert.Equal(25.40643236M, actual);
        }

        [Fact]
        public void Taxa12_15_1017dias_CondicaoResgate_DeveRetornar_Pu_1048_80885()
        {
            var ntnf = new NTNF();
            var actual = ntnf.PU(12.15, 1017, true);

            Assert.Equal(660.268663582M, actual);
        }

        [Fact]
        public void Taxa13_66_1415dias_CondicaoResgate_DeveRetornar_Pu_511_040083917()
        {
            var ntnf = new NTNF();
            var actual = ntnf.PU(13.66, 1415, true);

            Assert.Equal(511.040083917M, actual);
        }        

        [Fact]
        public void Taxa13_66_DiversosDias_CondicaoResgate_DeveRetornar_Pu_903_075616645()
        {
            var ntnf = new NTNF();
            var actual = ntnf.PU(13.66, new[] { 28, 159, 281, 409, 532, 660, 784, 911, 1036, 1162, 1285, 1415 }, true);

            Assert.Equal(903.075616645M, actual);
        }        

        [Fact]
        public void DeveRetornar_Cupom_48_80885()
        {
            var ntnf = new NTNF();
            var actual = ntnf.Cupom();

            Assert.Equal(48.80885M, actual);
        }

        [Fact]
        public void SemTruncar_DeveRetornar_Cupom_48_80885()
        {
            var ntnf = new NTNF();
            var actual = ntnf.Cupom(false, false);

            Assert.Equal(48.80885M, actual);
        }

        [Fact]
        public void CondicaoResgate_DeveRetornar_Cupom_1048_80885()
        {
            var ntnf = new NTNF();
            var actual = ntnf.Cupom(true);

            Assert.Equal(1048.80885M, actual);
        }

        [Fact]
        public void CondicaoResgate_SemTruncar_DeveRetornar_Cupom_1048_80885()
        {
            var ntnf = new NTNF();
            var actual = ntnf.Cupom(true, false);

            Assert.Equal(1048.80885M, actual);
        }
    }
}