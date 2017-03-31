using Xunit;

namespace Gandarez.RendaFixa.TD.Tests
{
    public class TresouroDiretoLFTTest
    {
        [Fact]
        public void TaxaN0_002_1459Dias_DeveRetornar_Cotacao_100_1158()
        {
            var lft = new LFT();
            var actual = lft.Cotacao(-0.02, 1459);

            Assert.Equal(100.1158M, actual);
        }

        [Fact]
        public void Taxa0_0511_1181Dias_DeveRetornar_Cotacao_99_7608()
        {
            var lft = new LFT();
            var actual = lft.Cotacao(0.0511, 1181);

            Assert.Equal(99.7608M, actual);
        }

        [Fact]
        public void Vna3451_215345_Cotacao100_1158_DeveRetornar_Pu_3455_211852()
        {
            var lft = new LFT();
            var actual = lft.PU(3451.215345M, 100.1158M);

            Assert.Equal(3455.211852M, actual);
        }
        
        [Fact]
        public void SelicAcumuladaAte20080520_3_4496942158456_DeveRetornar_Vna_3449_694215()
        {
            var lft = new LFT();
            var actual = lft.VNA(3.4496942158456M);

            Assert.Equal(3449.694215M, actual);
        }

        [Fact]
        public void VNA3449_694215_Taxa_11_75_DeveRetornar_Vna_3451_215345()
        {
            var lft = new LFT();
            var actual = lft.VNA(3449.694215M, new[] { 11.75M });

            Assert.Equal(3451.215345M, actual);
        }

        [Fact]
        public void VNA1000_Taxas_20_22_2Dias_DeveRetornar_Vna_1001_513733()
        {
            var lft = new LFT();
            var actual = lft.VNA(1000, new[] { 20M, 22M });

            Assert.Equal(1001.513733M, actual);
        }
    }
}