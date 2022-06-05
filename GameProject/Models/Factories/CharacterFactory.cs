using Game;
using GameProject.Enums;
using GameProject.Models.Factories.Concrete.Interface;

namespace GameProject.Models.Factories
{
    public abstract class CharacterFactory
    {
        public abstract ICharacter FactoryMethod();

        public Character Create(string nickname, ColorsEnum eyeColor, ColorsEnum hairColor, ColorsEnum skinColor)
        {
            var character = FactoryMethod();
            var classType = character.Create();

            SetInitialAttributes(classType, nickname, eyeColor, hairColor, skinColor);

            return (Character)classType;
        }

        public void SetInitialAttributes(Character character, string nickname, ColorsEnum eyeColor, ColorsEnum hairColor, ColorsEnum skinColor)
        {
            character.Nickname = nickname;
            character.EyeColor = eyeColor;
            character.HairColor = hairColor;
            character.SkinColor = skinColor;
        }
    }
}
