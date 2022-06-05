using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace GameUnitTest
{
    public class MageShould : IDisposable
    {

        private readonly Mage _sut;
        private readonly ITestOutputHelper _output;

        public void Dispose()
        {

            _output.WriteLine($"Disposing Mage {_sut.Nickname}");
            // _sut.Dispose();
        }

        public MageShould(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Creating a new Mage character");
            _sut = new Mage();

        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            var expectedWeapons = new List<Weapon>();
            expectedWeapons.Add(new Weapon("Mace of Destiny"));
            expectedWeapons.Add(new Weapon("Mace of Pace"));
            expectedWeapons.Add(new Weapon("Mace of Saturn"));

            Assert.Equal(expectedWeapons.Select(x => x.Name), _sut.Weapons.Select(y => y.Name));
        }

        [Fact]
        public void HaveNotAllExpectedWeapons()
        {
            var expectedWeapons = new List<Weapon>();
            expectedWeapons.Add(new Weapon("Hammer of Destiny"));
            expectedWeapons.Add(new Weapon("Hammer of Pace"));
            expectedWeapons.Add(new Weapon("Hammer of Saturn"));

            Assert.NotEqual(expectedWeapons.Select(x => x.Name), _sut.Weapons.Select(y => y.Name));
        }


        [Fact]
        public void HaveAtLeastOneKindOfMace()
        {
            Assert.Contains(_sut.Weapons, weapon => weapon.Name.Contains("Mace"));
        }

        [Fact]
        public void HaveAtLeastOneKindOfHat()
        {
            Assert.Equal(_sut.Accessories.Hat, "Hat");
        }

        //[Fact]
        //public void HaveAtLeastOneKindOfClothes()
        //{
        //    Assert.Contains(_sut.Weapons, weapon => weapon.Name.Contains("Mace"));
        //}

        //[Fact]
        //public void HaveAtLeastOneKindOfShoes()
        //{
        //    Assert.Contains(_sut.Weapons, weapon => weapon.Name.Contains("Mace"));
        //}

        //[Fact]
        //public void HaveAtLeastOneKindOfGloves()
        //{
        //    Assert.Contains(_sut.Weapons, weapon => weapon.Name.Contains("Mace"));
        //}
    }
}
