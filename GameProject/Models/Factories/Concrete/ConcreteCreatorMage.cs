using GameProject.Models.Factories.Concrete.Interface;

namespace GameProject.Models.Factories.Concrete
{
    public class ConcreteCreatorMage : CharacterFactory
    {
        public override ICharacter FactoryMethod()
        {
           return new ConcreteMage();
        }

    }
}
