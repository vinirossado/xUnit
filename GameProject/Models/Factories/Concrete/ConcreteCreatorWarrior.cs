using GameProject.Models.Factories.Concrete.Interface;

namespace GameProject.Models.Factories.Concrete
{
    public class ConcreteCreatorWarrior : CharacterFactory
    {
        public override ICharacter FactoryMethod()
        {
            return new ConcreteWarrior();
        }
    }
}
