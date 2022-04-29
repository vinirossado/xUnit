using System.Collections.Generic;

namespace Game
{
    public class Warrior : Character
    {
        public Warrior() { }

        public override double Power => 6;

        public override double Defense => 6;

        public override double Agility => 4;

        public override double Inteligence => 4;

        public override List<Weapon> Weapons => new List<Weapon>();

    }
}
