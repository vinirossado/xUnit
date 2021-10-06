using System;
using Xunit;
using Game;

namespace GameUnitTest
{
    public class BossEnemyShould
    {
        [Fact(Skip = "Don't need to run this")]
        [Trait("Category","Enemy")]
        public void HaveCorrectPower()
        {
            BossEnemy sut = new BossEnemy();

            Assert.Equal(166.667, sut.SpecialAttackPower, 3);
        }

    }
}
