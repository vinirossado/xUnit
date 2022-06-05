using Game;
using GameProject.DTO;

namespace GameProject.Infra.Repository
{
    public interface ICharacterRepository : IRepository<Character>
    {
        Task<Character> GetCharacterByIdAsync(string CharacterId);

        Task CreateCharacterAsync(CreateOrUpdateCharacterDto model);

        Task<Character> UpdateCharacterAsync(string id, CreateOrUpdateCharacterDto model);

        Task DeleteCharacterAsync(string id);
    }
}
