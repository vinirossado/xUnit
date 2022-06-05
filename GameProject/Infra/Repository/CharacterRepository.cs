using Game;
using GameProject.DTO;
using GameProject.Models.Factories.Concrete;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace GameProject.Infra.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IMongoCollection<Character> _character;

        public CharacterRepository(IMongoDatabase database)
        {
            _character = database.GetCollection<Character>("Character");
        }

        public async Task AddAsync(Character obj)
        {
            await _character.InsertOneAsync(obj);
        }

        public async Task CreateCharacterAsync(CreateOrUpdateCharacterDto model)
        {

            if ((int)model.CharacterType == 0)
            {
                var x = new ConcreteCreatorWarrior();
                var concreteMage = new ConcreteCreatorWarrior();
                var character = concreteMage.Create(model.Nickname, model.EyeColor, model.HairColor, model.SkinColor);

                await AddAsync(character);
            }

            if ((int)model.CharacterType == 1)
            {
                var concreteMage = new ConcreteCreatorMage();
                var character = concreteMage.Create(model.Nickname, model.EyeColor, model.HairColor, model.SkinColor);

                await AddAsync(character);
            }

        }

        public async Task DeleteAsync(Expression<Func<Character, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCharacterAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Character> GetAll()
        {
            return _character.AsQueryable();

        }

        public async Task<Character> GetCharacterByIdAsync(string CharacterId)
        {
            throw new NotImplementedException();
        }

        public async Task<Character> GetSingleAsync(Expression<Func<Character, bool>> predicate)
        {
            var filter = Builders<Character>.Filter.Where(predicate);
            return (await _character.FindAsync(filter)).FirstOrDefault();

        }

        public async Task<Character> UpdateAsync(Character obj)
        {
            //    var filter = Builders<Character>.Filter.Where(x => x.Id == obj.Id);

            //    // approach 1 - update selective properties
            //    var updateDefBuilder = Builders<Character>.Update;
            //    var updateDef = updateDefBuilder.Combine(new UpdateDefinition<Character>[]
            //    {
            //updateDefBuilder.Set(x => x.Name, obj.Name),
            //updateDefBuilder.Set(x => x.Description, obj.Description),
            //updateDefBuilder.Set(x => x.AuthorName, obj.AuthorName),
            //updateDefBuilder.Set(x => x.ISDN, obj.ISDN),
            //updateDefBuilder.Set(x => x.Price, obj.Price)
            //    });
            //    return await _character.FindOneAndUpdateAsync(filter, updateDef);

            //    // approach 2 - replace the entire record
            //return await _character.FindOneAndReplaceAsync(x => x.Id == obj.Id, obj);
            return new Warrior();
        }

        public async Task<Character> UpdateCharacterAsync(string id, CreateOrUpdateCharacterDto model)
        {
            //Book book = new Book
            //{
            //    Id = id,
            //    Name = model.Name,
            //    AuthorName = model.AuthorName,
            //    ISDN = model.ISDN,
            //    Description = model.Description,
            //    Price = model.Price,
            //    AddedOn = DateTime.Now
            //};

            return await UpdateAsync(new Mage());
        }
    }
}
