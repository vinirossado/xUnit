using GameProject.Models;
using System.Collections.Generic;

namespace Game
{
    public class Warrior : Character
    {
        public Warrior()
        {
        }

        public override double Power { get => 6; set => throw new Exception(); }

        public override double Defense { get => 6; set => throw new Exception(); }

        public override double Agility { get => 4; set => throw new Exception(); }

        public override double Inteligence { get => 4; set => throw new Exception(); }

        public override List<Weapon> Weapons { get; set; }
        public override Accessories Accessories { get; set; }
    }
}
