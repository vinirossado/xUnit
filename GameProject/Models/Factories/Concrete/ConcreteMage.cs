using Game;
using GameProject.Models.Factories.Concrete.Interface;

namespace GameProject.Models.Factories.Concrete
{
    public class ConcreteMage : ICharacter
    {
        public Character Create()
        {
            return new Mage();
        }
    }
}
