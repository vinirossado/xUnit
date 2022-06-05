using GameProject.Infra.Repository;

namespace GameProject.Infra.Configs
{
    public class DataService : IDataService
    {
        private readonly MongoContext _dbContext;

        public DataService(MongoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICharacterRepository Characters => new CharacterRepository(_dbContext.Database);
    }
}
