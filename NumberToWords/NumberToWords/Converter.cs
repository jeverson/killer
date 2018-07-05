using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberToWords
{
    public class Converter
    {
        private Plurals _plurals;
        private SimpleNumbers _simpleNumbers;

        public Converter()
        {
            _simpleNumbers = new SimpleNumbers();
            _plurals = new Plurals();
        }

        public string Convert(int number) {
            if (_simpleNumbers.CanConvert(number))
                return _simpleNumbers.Convert(number);

            return ConvertNumber(number);            
        }

        private string ConvertNumber(int number) {

            var higherNumber = _simpleNumbers.Closest(number);            
            var howManyTimes = number / higherNumber;
            var remaining = number % higherNumber;
            
            if (remaining == 0) 
                return GetWord(higherNumber, howManyTimes);
            
            var remainingWords = AddAndIfApplicable(higherNumber, remaining) + Convert(remaining);
            return $"{GetWord(higherNumber, howManyTimes)} {remainingWords}";
        }

        private string AddAndIfApplicable(int number, int remaining) => 
            (remaining <= 100) ? "e " : "";

        private string GetWord(int number, int times) =>
                (times > 1) ? 
                $"{Convert(times)} {GetPlural(number)}" :
                GetSimpleWord(number);

        private string GetPlural(int number) =>
             _plurals.CanConvert(number) ?
                _plurals.Convert(number) :
                _simpleNumbers.Convert(number);

        private string GetSimpleWord(int number) {
            return !IsDifferentWhenWithOtherNumbers(number) ?
                _simpleNumbers.Convert(number) : 
                SpecialCaseWhenWithOtherNumbers(number);
        }

        private bool IsDifferentWhenWithOtherNumbers(int number)
            => (number == 100);
        
        private string SpecialCaseWhenWithOtherNumbers(int number) 
            => "Cento";
    }
}
