using System.Collections.Generic;

namespace Game
{
    public abstract class Character : Characteristics
    {
        public string Nickname { get; set; }
        public abstract double Power { get; }
        public abstract double Defense { get; }
        public abstract double Agility { get; }
        public abstract double Inteligence { get; }
        public abstract List<Weapon> Weapons { get; }
        //public double SpecialAttackPower => TotalSpecialPower / SpecialAttackPower;
    }
}
