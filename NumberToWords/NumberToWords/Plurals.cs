using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberToWords
{
    public class Plurals {
        private Dictionary<int, string> _plurals;

        public Plurals()
        {
            _plurals = new Dictionary<int, string>();
            _plurals.Add(1000000, "Milhões");
            _plurals.Add(1000000000, "Bilhões");         
        }

        public bool CanConvert(int number) =>
            _plurals.ContainsKey(number);
        
        public string Convert(int number) => _plurals[number];

        public bool IsPlural(int times) => times > 1;
    }
}