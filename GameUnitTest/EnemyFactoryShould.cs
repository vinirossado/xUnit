using System;
using Xunit;
using Game;
namespace GameUnitTest
{
    public class EnemyFactoryShould
    {
        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact]
        public void CreateNormalEnemyByDefault_NotType()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsNotType<BossEnemy>(enemy);
        }


        [Fact]
        public void CreateBossEnemy()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Maiden", true);

            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_NotType()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Maiden", true);

            Assert.IsNotType<NormalEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedType()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Iron Maiden", true);

            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            Assert.Equal("Iron Maiden", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Iron Maiden", true);

            Assert.IsAssignableFrom<Enemy>(enemy);
        }


        [Fact]
        public void CreateSeparateInstances()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy1 = sut.Create("Iron Maiden", true);
            Enemy enemy2 = sut.Create("Iron Maiden", true);

            Assert.NotSame(enemy1, enemy2);
        }

        [Fact]
        public void NotAllowNullName()
        {
            EnemyFactory sut = new EnemyFactory();

            Assert.Throws<ArgumentNullException>("name", () => sut.Create(null));
        }

        [Fact]
        public void OnlyAllowMaidenBossEnemy()
        {
            EnemyFactory sut = new EnemyFactory();

            EnemyCreationException ex = Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));
        }
    }
}
