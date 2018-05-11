using System;
using System.Linq;

namespace Killer
{
    public class EyeWitness : IWitnessedTheCrime {
    
        private enum TheoryFlaws {
            None = 0,
            Killer = 1,
            Place = 2,
            Weapon = 3    
        }
        
        private readonly CrimeDetails _crime;
        public EyeWitness(CrimeDetails crime) {
            _crime = crime;
        }
        
        public int ProbeTheory(CrimeDetails theory) {
            var result = new int[] {
                (int) ProbeKiller(theory.Killer), 
                (int) ProbePlace(theory.Place),
                (int) ProbeWeapon(theory.Weapon)
            }.Max();
            return result;
        }


        private TheoryFlaws ProbePlace(int place)
        {
            return (_crime.Place == place) ? TheoryFlaws.None : TheoryFlaws.Place;
        }

        private TheoryFlaws ProbeKiller(int killer) {
            return (_crime.Killer == killer) ? TheoryFlaws.None : TheoryFlaws.Killer;
        }

        private TheoryFlaws ProbeWeapon(int weapon)
        {
            return (_crime.Weapon == weapon) ? TheoryFlaws.None : TheoryFlaws.Weapon;
        }
    }
}