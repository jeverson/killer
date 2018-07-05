using System;
using Xunit;

namespace NumberToWords.Tests
{
    public class ConverterTest
    {
        private Converter _sut = new Converter();

        [Theory]
        [InlineData(0, "Zero")]
        [InlineData(1, "Um")]
        [InlineData(2, "Dois")]
        [InlineData(18, "Dezoito")]
        [InlineData(20, "Vinte")]
        [InlineData(50, "Cinquenta")]
        [InlineData(100, "Cem")]
        [InlineData(700, "Setecentos")]
        [InlineData(1000, "Mil")]
        public void Convert_WhenReceivingSimpleNumbers_ShouldReturn(int number, string words)
        {
            RunAndAssert(number, words);
        }

        [Theory]
        [InlineData(41, "Quarenta e Um")]
        [InlineData(53, "Cinquenta e Três")]
        [InlineData(64, "Sessenta e Quatro")]
        [InlineData(75, "Setenta e Cinco")]
        [InlineData(86, "Oitenta e Seis")]
        [InlineData(97, "Noventa e Sete")]
        public void Convert_WhenReceivingLessThanHundred_ShouldReturn(int number, string words) {
            RunAndAssert(number, words);        
        }

        [Theory]
        [InlineData(101, "Cento e Um")]
        [InlineData(110, "Cento e Dez")]
        [InlineData(111, "Cento e Onze")]
        [InlineData(199, "Cento e Noventa e Nove")]
        public void Convert_WhenReceivingBetweenOneAndTwoHundreds_ShouldReturn(int number, string words) {
            RunAndAssert(number, words);
        }

        [Theory]
        [InlineData(201, "Duzentos e Um")]
        [InlineData(410, "Quatrocentos e Dez")]
        [InlineData(611, "Seiscentos e Onze")]
        [InlineData(999, "Novecentos e Noventa e Nove")]
        public void Convert_WhenReceivingBetweenTwoHundredsAndOneThousand_ShouldReturn(int number, string words) {
            RunAndAssert(number, words);
        }

        [Theory]
        [InlineData(1001, "Mil e Um")]
        [InlineData(2001, "Dois Mil e Um")]
        [InlineData(10000, "Dez Mil")]
        [InlineData(10100, "Dez Mil e Cem")]
        [InlineData(10101, "Dez Mil Cento e Um")]
        [InlineData(10199, "Dez Mil Cento e Noventa e Nove")]
        [InlineData(99999, "Noventa e Nove Mil Novecentos e Noventa e Nove")]
        public void Convert_WhenReceivingMoreThanOneThousand_ShouldReturn(int number, string words) {
            RunAndAssert(number, words);
        }

        [Theory]
        [InlineData(1000001, "Um Milhão e Um")]
        [InlineData(2000001, "Dois Milhões e Um")]
        [InlineData(99999999, "Noventa e Nove Milhões Novecentos e Noventa e Nove Mil Novecentos e Noventa e Nove")]
        public void Convert_WhenReceivingMillionsOrBillions_ShouldReturn(int number, string words) {
            RunAndAssert(number, words);
        }

        private void RunAndAssert(int number, string words) {
            var result = _sut.Convert(number);
            Assert.Equal(words, result);
        }
    }
}
