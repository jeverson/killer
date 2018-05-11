using System;
using Xunit;

namespace Killer.Tests
{
    public class EyeWitnessTest
    {

        private readonly CrimeDetails _crime;
        private readonly EyeWitness _sut;
    
        public EyeWitnessTest() {
            _crime = new CrimeDetails(1, 2, 3);
            _sut = new EyeWitness(_crime);
        }

        [Fact]
        public void ProbeTheory_ShouldReturn1_WhenSuspectIsIncorrect() {
            var ret = _sut.ProbeTheory(new CrimeDetails(2, 2, 3));
            Assert.Equal(1, ret);
        }

        [Fact]  
        public void ProbeTheory_ShouldReturn2_WhenPlaceIsIncorrect() {
            var ret = _sut.ProbeTheory(new CrimeDetails(1, 1, 3));
            Assert.Equal(2, ret);
        }

        [Fact]  
        public void ProbeTheory_ShouldReturn3_WhenWeaponIsIncorrect() {
            var ret = _sut.ProbeTheory(new CrimeDetails(1, 2, 2));
            Assert.Equal(3, ret);
        }

        [Fact]  
        public void ProbeTheory_ShouldReturn0_WhenEverythingIsCorrect() {
            var ret = _sut.ProbeTheory(new CrimeDetails(1, 2, 3));
            Assert.Equal(0, ret);
        }
    }
}