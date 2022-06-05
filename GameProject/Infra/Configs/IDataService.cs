using GameProject.Infra.Repository;

namespace GameProject.Infra.Configs
{
    public interface IDataService
    {
        public ICharacterRepository Characters { get; }
    }
}
