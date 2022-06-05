using Game;
using GameProject.Models.Factories.Concrete.Interface;

namespace GameProject.Models.Factories.Concrete
{
    public class ConcreteWarrior : ICharacter
    {
        public Character Create()
        {
            return new Warrior();
        }

    }
}
