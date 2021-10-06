using System;
using Xunit;
using Game;
using System.Collections.Generic;

namespace GameUnitTest
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperiencedWhenNew()
        {
            var sut = new PlayerCharacter();
            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Vinicius";
            sut.LastName = "Rossado";

            Assert.Equal("Vinicius Rossado", sut.FullName);
        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Vinicius";
            sut.LastName = "Rossado";

            Assert.StartsWith("Vinicius", sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssert()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "VINICIUS";
            sut.LastName = "ROSSADO";

            Assert.Equal("Vinicius Rossado", sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubstringAssert()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Vinicius";
            sut.LastName = "Rossado";

            Assert.Contains("us Ro", sut.FullName);
        }

        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Vinicius";
            sut.LastName = "Rossado";
            //Regex irá validar se cada começo de palavra é contem uma letra maiuscula seguida de uma minuscula
            //Ex: Vi de Vinicius e Ro de Rossado
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Equal(100, sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqual()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.NotEqual(0, sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.Sleep();

            Assert.InRange<int>(sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Null(sut.NickName);
        }

        [Fact]
        public void HaveALongHammer()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains("Long Hammer", sut.Weapons);
        }

        [Fact]
        public void HaveThreeWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            // Assert.True(3, sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfHammer()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Hammer"));
        }


        [Fact]
        public void HaveAllExpectedWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            var expectedWeapons = new[] {
                "Long Bow",
                "Short Bow",
                "Short Sword",
                "Long Hammer",
            };

            Assert.Equal(expectedWeapons, sut.Weapons);
        }


        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.All(sut.Weapons, weapon => Assert.False(String.IsNullOrEmpty(weapon)));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep());
        }

        // [Fact]
        // public void RaisePropertyChangedEvent()
        // {
        //     PlayerCharacter sut = new PlayerCharacter();
        //     Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10));
        // }
    }
}
