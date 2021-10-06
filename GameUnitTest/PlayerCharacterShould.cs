using System;
using Xunit;
using Xunit.Abstractions;
using Game;
using System.Collections.Generic;

namespace GameUnitTest
{
    public class PlayerCharacterShould : IDisposable
    {
        private readonly PlayerCharacter _sut;
        private readonly ITestOutputHelper _output;

        public PlayerCharacterShould(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Creating a new player character");
            _sut = new PlayerCharacter();

        }

        public void Dispose()
        {

            _output.WriteLine($"Disposing PlayerCharacter {_sut.FullName}");
            // _sut.Dispose();
        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            Assert.True(_sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            _sut.FirstName = "Vinicius";
            _sut.LastName = "Rossado";

            Assert.Equal("Vinicius Rossado", _sut.FullName);
        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            _sut.FirstName = "Vinicius";
            _sut.LastName = "Rossado";

            Assert.StartsWith("Vinicius", _sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssert()
        {
            _sut.FirstName = "VINICIUS";
            _sut.LastName = "ROSSADO";

            Assert.Equal("Vinicius Rossado", _sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubstringAssert()
        {
            _sut.FirstName = "Vinicius";
            _sut.LastName = "Rossado";

            Assert.Contains("us Ro", _sut.FullName);
        }

        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            _sut.FirstName = "Vinicius";
            _sut.LastName = "Rossado";
            //Regex irá validar se cada começo de palavra é contem uma letra maiuscula seguida de uma minuscula
            //Ex: Vi de Vinicius e Ro de Rossado
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {

            Assert.Equal(100, _sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqual()
        {

            Assert.NotEqual(0, _sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {

            _sut.Sleep();

            Assert.InRange<int>(_sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {

            Assert.Null(_sut.NickName);
        }

        [Fact]
        public void HaveALongHammer()
        {

            Assert.Contains("Long Hammer", _sut.Weapons);
        }

        [Fact]
        public void HaveThreeWeapons()
        {

            // Assert.True(3, _sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfHammer()
        {

            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Hammer"));
        }


        [Fact]
        public void HaveAllExpectedWeapons()
        {

            var expectedWeapons = new[] {
                "Long Bow",
                "Short Bow",
                "Short Sword",
                "Long Hammer",
            };

            Assert.Equal(expectedWeapons, _sut.Weapons);
        }


        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {

            Assert.All(_sut.Weapons, weapon => Assert.False(String.IsNullOrEmpty(weapon)));
        }

        [Fact]
        public void RaiseSleptEvent()
        {

            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep());
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        // [Fact]
        // public void RaisePropertyChangedEvent()
        // {
        //     Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
        // }
    }
}
