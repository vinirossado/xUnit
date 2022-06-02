using System;

namespace Game
{
    public class BossEnemy : Enemy
    {
        public BossEnemy(){}

        public override double TotalSpecialPower => 1000;
        public override double SpecialPowerUses => 6;
    }
}
