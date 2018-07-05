using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberToWords
{
    public class Converter
    {
        private Dictionary<int, string> _simpleNumbers;
        private Dictionary<int, string> _plurals;

        public Converter()
        {
            _plurals = new Dictionary<int, string>();
            _plurals.Add(1000000, "Milhões");

            _simpleNumbers = new Dictionary<int, string>();
            _simpleNumbers.Add(0, "Zero");
            _simpleNumbers.Add(1, "Um");
            _simpleNumbers.Add(2, "Dois");
            _simpleNumbers.Add(3, "Três");
            _simpleNumbers.Add(4, "Quatro");
            _simpleNumbers.Add(5, "Cinco");
            _simpleNumbers.Add(6, "Seis");
            _simpleNumbers.Add(7, "Sete");
            _simpleNumbers.Add(8, "Oito");
            _simpleNumbers.Add(9, "Nove");
            _simpleNumbers.Add(10, "Dez");
            _simpleNumbers.Add(11, "Onze");
            _simpleNumbers.Add(12, "Doze");
            _simpleNumbers.Add(13, "Treze");
            _simpleNumbers.Add(14, "Quatorze");
            _simpleNumbers.Add(15, "Quinze");
            _simpleNumbers.Add(16, "Dezesseis");
            _simpleNumbers.Add(17, "Dezessete");
            _simpleNumbers.Add(18, "Dezoito");
            _simpleNumbers.Add(19, "Dezenove");
            _simpleNumbers.Add(20, "Vinte");
            _simpleNumbers.Add(30, "Trinta");
            _simpleNumbers.Add(40, "Quarenta");
            _simpleNumbers.Add(50, "Cinquenta");
            _simpleNumbers.Add(60, "Sessenta");
            _simpleNumbers.Add(70, "Setenta");
            _simpleNumbers.Add(80, "Oitenta");
            _simpleNumbers.Add(90, "Noventa");
            _simpleNumbers.Add(100, "Cem");
            _simpleNumbers.Add(200, "Duzentos");
            _simpleNumbers.Add(300, "Trezentos");
            _simpleNumbers.Add(400, "Quatrocentos");
            _simpleNumbers.Add(500, "Quinhentos");
            _simpleNumbers.Add(600, "Seiscentos");
            _simpleNumbers.Add(700, "Setecentos");
            _simpleNumbers.Add(800, "Oitocentos");
            _simpleNumbers.Add(900, "Novecentos");
            _simpleNumbers.Add(1000, "Mil");
        }

        public string Convert(int number) {
            if (_simpleNumbers.ContainsKey(number))
                return GetFromSimpleNumbers(number);

            return ConvertNumber(number);            
        }

        private string ConvertNumber(int number) {
            var higherNumber = _simpleNumbers.Keys
                .OrderByDescending(k => k)
                .First(k => k < number);
            
            var howManyTimes = number / higherNumber;
            var remaining = number % higherNumber;
            
            if (remaining == 0) 
                return GetWord(higherNumber, howManyTimes);
            
            var remainingWords = GetConjunction(higherNumber, remaining) + Convert(remaining);
            return $"{GetWord(higherNumber, howManyTimes)} {remainingWords}";
        }

        private string GetConjunction(int number, int remaining) => 
            (remaining <= 100)
                ?
                "e " : 
                "";

        private string GetWord(int number, int times) =>
                (times > 1) ? 
                $"{Convert(times)} {GetPlural(number)}" :
                GetSimpleWord(number);

        private string GetPlural(int number) =>
             _plurals.ContainsKey(number) ?
                _plurals[number] :
                _simpleNumbers[number];

        private string GetSimpleWord(int number) {
            return !IsDifferentWhenWithOtherNumbers(number) ?
                GetFromSimpleNumbers(number) : 
                SpecialCaseWhenWithOtherNumbers(number);
        }

        private string GetFromSimpleNumbers(int number) => 
            _simpleNumbers[number];

        private bool IsDifferentWhenWithOtherNumbers(int number)
            => (number == 100);
        
        private string SpecialCaseWhenWithOtherNumbers(int number) 
            => "Cento";
    }
}
