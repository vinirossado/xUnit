using System;
using Xunit;
using Game;
namespace GameUnitTest
{
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
        private readonly EnemyFactory _sut;

        public EnemyFactoryShould() => _sut = new EnemyFactory();

        [Fact]
        public void CreateNormalEnemyByDefault()
        {

            Enemy enemy = _sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact]
        public void CreateNormalEnemyByDefault_NotType()
        {

            Enemy enemy = _sut.Create("Zombie");

            Assert.IsNotType<BossEnemy>(enemy);
        }


        [Fact]
        public void CreateBossEnemy()
        {

            Enemy enemy = _sut.Create("Maiden", true);

            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_NotType()
        {

            Enemy enemy = _sut.Create("Maiden", true);

            Assert.IsNotType<NormalEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedType()
        {

            Enemy enemy = _sut.Create("Iron Maiden", true);

            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            Assert.Equal("Iron Maiden", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {

            Enemy enemy = _sut.Create("Iron Maiden", true);

            Assert.IsAssignableFrom<Enemy>(enemy);
        }


        [Fact]
        public void CreateSeparateInstances()
        {
            Enemy enemy1 = _sut.Create("Iron Maiden", true);
            Enemy enemy2 = _sut.Create("Iron Maiden", true);

            Assert.NotSame(enemy1, enemy2);
        }

        [Fact]
        public void NotAllowNullName()
        {
            Assert.Throws<ArgumentNullException>("name", () => _sut.Create(null));
        }

        [Fact]
        public void OnlyAllowMaidenBossEnemy()
        {
            EnemyCreationException ex = Assert.Throws<EnemyCreationException>(() => _sut.Create("Zombie", true));
        }
    }
}
