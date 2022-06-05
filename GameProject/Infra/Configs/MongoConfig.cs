using GameProject.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GameProject.Infra.Configs
{
    public class MongoContext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoContext(IOptions<DatabaseSettings> dbOptions)
        {
            var settings = dbOptions.Value;
            _client = new MongoClient(LaunchEnvironment.DbConnection);
            _database = _client.GetDatabase(LaunchEnvironment.DbName);
        }

        public IMongoClient Client => _client;

        public IMongoDatabase Database => _database;
    }
}
