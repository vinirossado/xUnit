using System;
using System.Runtime.Serialization;

namespace Game
{
    [Serializable]
    public class EnemyCreationException : Exception
    {
        private string v;
        private string name;

        public EnemyCreationException()
        {
        }

        public EnemyCreationException(string message) : base(message)
        {
        }

        public EnemyCreationException(string v, string name)
        {
            this.v = v;
            this.name = name;
        }

        public EnemyCreationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EnemyCreationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}