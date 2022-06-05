using GameProject.Models;
using System.Collections.Generic;

namespace Game
{
    public class Mage : Character
    {
        public Mage() { }

        public override double Power { get => 8; set => throw new NotImplementedException(); }

        public override double Defense { get => 4; set => throw new NotImplementedException(); }

        public override double Agility { get => 5; set => throw new NotImplementedException(); }

        public override double Inteligence { get => 7; set => throw new NotImplementedException(); }

        public override List<Weapon> Weapons { get => GenerateMageWeapons(); set => throw new NotImplementedException(); }

        public override Accessories Accessories { get => GenerateMageAccessories(); set => throw new NotImplementedException(); }

        public static List<Weapon> GenerateMageWeapons()
        {
            var list = new List<Weapon>();
            list.Add(new Weapon("Mace of Destiny"));
            list.Add(new Weapon("Mace of Pace"));
            list.Add(new Weapon("Mace of Saturn"));

            return list;
        }

        public static Accessories GenerateMageAccessories()
        {
            var accessories = new Accessories("Shoe", "Glove", "Clothe", "Hat", "Pant");
            return accessories;
        }

        protected void SetInitialCharacteristics()
        {
            Accessories.Hat = "AAAAAAAAAA";
        }
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
