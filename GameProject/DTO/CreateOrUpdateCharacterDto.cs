using Game;
using GameProject.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameProject.DTO
{
    public class CreateOrUpdateCharacterDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Nickname { get; set; }
        public CharacterType CharacterType { get; set; }
        public int CharacterTypeId { get; set; }
        public ColorsEnum EyeColor { get; set; }
        public ColorsEnum SkinColor { get; set; }
        public ColorsEnum HairColor { get; set; }

    }

    public enum CharacterType
    {
        Warrior,
        Mage,
    }
}
