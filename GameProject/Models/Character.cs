using GameProject.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Game
{
    public abstract class Character : Characteristics
    {

        public Character()
        {
            AddedOn = DateTime.Now;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nickname { get; set; }
        public abstract double Power { get; set; }
        public abstract double Defense { get; set; }
        public abstract double Agility { get; set; }
        public abstract double Inteligence { get; set; }
        public abstract List<Weapon> Weapons { get; set; }
        public abstract Accessories Accessories { get; set; }
        public DateTime AddedOn { get; set; }
        //public double SpecialAttackPower => TotalSpecialPower / SpecialAttackPower;

    }
}
