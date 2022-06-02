using System;

namespace Game
{
    public class EnemyFactory
    {
        public Enemy Create(string name, bool isBoss = false)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name));

            if (isBoss)
            {
                if (!IsValidBossName(name))
                {
                    throw new EnemyCreationException(
                    $"{name} is not a valid name for a boss enemy, boss enemy names must end with", name);
                }
                return new BossEnemy { Name = name };
            }
            return new NormalEnemy { Name = name };
        }

        private bool IsValidBossName(string name) => name.EndsWith("Maiden");

    }
}
