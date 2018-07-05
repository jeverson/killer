using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberToWords
{
    public class SimpleNumbers {
        private Dictionary<int, string> _simpleNumbers;

        public SimpleNumbers()
        {
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
            _simpleNumbers.Add(1000000, "Um Milhão");
            _simpleNumbers.Add(1000000000, "Um Bilhão");            
        }

        public bool CanConvert(int number) =>
            _simpleNumbers.ContainsKey(number);
        
        public string Convert(int number) => _simpleNumbers[number];
        
        public int Closest(int number) => 
            _simpleNumbers.Keys
                .OrderByDescending(k => k)
                .First(k => k < number);

    }
}