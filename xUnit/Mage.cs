using System.Collections.Generic;

namespace Game
{
    public class Mage  : Character
    {
        public Mage() {}
        
        public override double Power => 8;

        public override double Defense => 4;

        public override double Agility => 5;

        public override double Inteligence => 7;

        public override List<Weapon> Weapons => new List<Weapon>();

        public override bool Equals(object obj)
        {
            return obj is Mage mage &&
                   EyeColor == mage.EyeColor &&
                   SkinColor == mage.SkinColor &&
                   HairColor == mage.HairColor &&
                   Nickname == mage.Nickname &&
                   Power == mage.Power &&
                   Defense == mage.Defense &&
                   Agility == mage.Agility &&
                   Inteligence == mage.Inteligence;
        }
    }
}
